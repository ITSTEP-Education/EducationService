
namespace AspNetWeb_NLayer.BLL.Infrastructure
{
    public class StatusCode200 : StatusCode
    {
        public StatusCode200() : base(200, "request done") { }
        public StatusCode200(string msg) : base(200, msg) { }
        public StatusCode200(int statusCode, string msg) : base(statusCode, msg) { }
    }
}
