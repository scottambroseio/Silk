using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Silk.Core;

namespace Silk.Example
{
    public class IndexHandler : IHttpRequestHandler
    {
        public Task<IHttpResponse> ExecuteAsync(HttpContext context)
        {
            IHttpResponse response = new StringResponse(context, "Hello world!");

            return Task.FromResult(response);
        }
    }
}
