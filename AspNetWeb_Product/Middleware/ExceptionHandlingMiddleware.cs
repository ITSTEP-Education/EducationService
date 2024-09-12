using AspNetWeb_NLayer.BLL.Infrastructure;
using Newtonsoft.Json;

namespace AspNetWeb_Product.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;
        private readonly ILogger<ExceptionHandlingMiddleware> logger;
        private static int iteration;

        public ExceptionHandlingMiddleware
        (RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.requestDelegate = requestDelegate;
            this.logger = logger;
        }

        static ExceptionHandlingMiddleware()
        {
            iteration = 0;
        }

        public async Task Invoke(HttpContext context)
        {
            if (iteration == 0) {
                logger.LogInformation(201, "Created entity of ExceptionHandlingMiddleware");
                iteration++;
                return;
            }

            bool isExcept = false;
            var midContext = new { TypeMethod = context.Request.Method, NameMethod = context.Request.RouteValues["action"], QueryParam = context.Request.QueryString, RequestPath = context.Request.Path };

            try
            {
                logger.LogInformation(context.Response.StatusCode, $"PL: started Http{midContext.TypeMethod} {midContext.NameMethod} ({midContext.QueryParam}). Route: {midContext.RequestPath}");
                await requestDelegate(context);
            }
            catch (ProductItemException ex)
            {
                isExcept = true;
                logger.LogError(ex.code, $"PL: failed Http{midContext.TypeMethod} {midContext.NameMethod} ({midContext.QueryParam}). {ex.Message} {ex.property}");
                await HandleException(context, ex);
            }
            finally
            {
                if (!isExcept)
                    logger.LogInformation(context.Response.StatusCode, $"PL: closed Http{midContext.TypeMethod} {midContext.NameMethod} ({midContext.QueryParam}). Route: {midContext.RequestPath}");
            }
        }

        private Task HandleException(HttpContext context, ProductItemException ex)
        {
            var errorMessageObject = new { code = ex.code, msg = ex.Message, prop = ex.property };

            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);
            context.Response.ContentType = "application/json";
            //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode = ex.code;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}
