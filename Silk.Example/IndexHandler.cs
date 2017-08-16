using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Silk.Core;
using Silk.Core.Attributes;
using Silk.Core.Responses;

namespace Silk.Example
{
    [Route("/")]
    public class IndexHandler : IHttpRequestHandler
    {
        private readonly IGreeterService _greeterService;

        public IndexHandler(IGreeterService greeterService)
        {
            _greeterService = greeterService;
        }

        public Task<IHttpResponse> ExecuteAsync(HttpContext context)
        {
            IHttpResponse response = new StringResponse(context, _greeterService.GetGreeting());

            return Task.FromResult(response);
        }
    }
}
