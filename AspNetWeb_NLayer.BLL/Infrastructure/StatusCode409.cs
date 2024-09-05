
namespace AspNetWeb_NLayer.BLL.Infrastructure
{
    public class StatusCode409 : StatusCode
    {
        public StatusCode409() : base(409, "no connection to db") { }
        public StatusCode409(string msg) : base(409, msg) { }
        public StatusCode409(int statusCode, string msg) : base(statusCode, msg) { }
    }
}
