using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Silk.Core
{
    public interface IHttpRequestHandler
    {
        Task<IHttpResponse> ExecuteAsync(HttpContext context);
    }
}