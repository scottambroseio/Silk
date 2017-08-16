using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Silk.Core;
using Silk.Core.Attributes;

namespace Silk.Example
{
    [Route("/foo")]
    public class FooHandler : IHttpRequestHandler
    {
        public Task<IHttpResponse> ExecuteAsync(HttpContext context)
        {
            IHttpResponse response = new StringResponse(context, "Foo");

            return Task.FromResult(response);
        }
    }
}
