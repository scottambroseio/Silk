using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Silk.Core;
using Silk.Core.Attributes;
using Silk.Core.Responses;

namespace Silk.Example
{
    [Route("/foo")]
    public class FooHandler : IHttpRequestHandler
    {
        public Task<IHttpResponse> ExecuteAsync(HttpContext context)
        {
            IHttpResponse response = new HtmlResponse(context, "<h1>Foo</h1>");

            return Task.FromResult(response);
        }
    }
}
