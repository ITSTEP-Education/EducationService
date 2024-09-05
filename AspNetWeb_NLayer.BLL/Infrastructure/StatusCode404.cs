
namespace AspNetWeb_NLayer.BLL.Infrastructure
{
    public class StatusCode404 : StatusCode
    {
        public StatusCode404() : base(404, "records are absent in db") { }
        public StatusCode404(string msg) : base(404, msg) { }
        public StatusCode404(int statusCode, string msg) : base(statusCode, msg) { }
    }
}
