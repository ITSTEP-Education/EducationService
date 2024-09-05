
namespace AspNetWeb_NLayer.BLL.Infrastructure
{
    public class StatusCode201 : StatusCode
    {
        public StatusCode201() : base(201, "item was added to db") { }
        public StatusCode201(string msg) : base(201, msg) { }
        public StatusCode201(int statusCode, string msg) : base(statusCode, msg) { }
    }
}
