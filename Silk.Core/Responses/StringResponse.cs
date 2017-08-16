using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Silk.Core.Responses
{
    public class StringResponse : IHttpResponse
    {
        private readonly string _content;
        private readonly HttpContext _context;

        public StringResponse(HttpContext context, string content)
        {
            _context = context;
            _content = content;
        }

        public async Task ExecuteAsync()
        {
            _context.Response.ContentType = "text/plain";
            _context.Response.StatusCode = (int) HttpStatusCode.OK;
            _context.Response.ContentLength = _content.Length;

            await _context.Response.WriteAsync(_content);
        }
    }
}