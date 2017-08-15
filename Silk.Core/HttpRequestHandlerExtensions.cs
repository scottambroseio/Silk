using Microsoft.AspNetCore.Http;

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