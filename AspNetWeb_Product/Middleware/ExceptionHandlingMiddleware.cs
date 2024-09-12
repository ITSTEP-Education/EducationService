using AspNetWeb_NLayer.BLL.Infrastructure;
using Newtonsoft.Json;
using System.Net;

namespace AspNetWeb_Product.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;
        private readonly ILogger<ExceptionHandlingMiddleware> logger;
        public ExceptionHandlingMiddleware
        (RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.requestDelegate = requestDelegate;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            bool isExcept = false;

            try
            {
                logger.LogInformation(301, "started HttpGet GetProductItem by xxx. Url: {@RequestPath}", context.Request.Path);
                await requestDelegate(context);
            }

            catch (ProductItemException ex)
            {
                isExcept = true;
                logger.LogError(301, new ProductItemException(ex), "failed HttpGet GetProductItem by xxx. Url: {@RequestPath}", context.Request.Path);
            }
            finally
            {
                if (!isExcept)
                    logger.LogInformation(304, "closed HttpGet GetProductItem by xxx. Url: {@RequestPath}", context.Request.Path);
            }

            //catch (Exception ex)
            //{
            //    await HandleException(context, ex);
            //}
        }

        //private Task HandleException(HttpContext context, Exception ex)
        //{
        //    logger.LogError(ex.ToString());
        //    var errorMessageObject =
        //        new { Message = ex.Message, Code = "system_error" };

        //    var errorMessage = JsonConvert.SerializeObject(errorMessageObject);
        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //    return context.Response.WriteAsync(errorMessage);
        //}
    }
}
