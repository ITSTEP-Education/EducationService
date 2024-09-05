
namespace AspNetWeb_NLayer.BLL.Infrastructure
{
    public class StatusCode400 : StatusCode
    {
        public StatusCode400() : base(400, "inputed uncorrect format") { }
        public StatusCode400(string msg) : base(400, msg) { }
        public StatusCode400(int statusCode, string msg) : base(statusCode, msg) { }
    }
}
