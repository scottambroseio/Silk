using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Silk.Core.Responses
{
    public class HtmlResponse : IHttpResponse
    {
        private readonly string _html;
        private readonly HttpContext _context;

        public HtmlResponse(HttpContext context, string html)
        {
            _context = context;
            _html = html;
        }

        public async Task ExecuteAsync()
        {
            _context.Response.ContentType = "text/html";
            _context.Response.StatusCode = (int)HttpStatusCode.OK;
            _context.Response.ContentLength = _html.Length;

            await _context.Response.WriteAsync(_html);
        }
    }
}
