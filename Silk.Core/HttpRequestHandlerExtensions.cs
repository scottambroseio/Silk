using Microsoft.AspNetCore.Http;
using Silk.Core.Responses;

namespace Silk.Core
{
    public static class HttpRequestHandlerExtensions
    {
        public static IHttpResponse ContentResponse(this IHttpRequestHandler handler, HttpContext context,
            string content)
        {
            return new StringResponse(context, content);
        }
    }
}