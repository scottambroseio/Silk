using System.Threading.Tasks;

namespace Silk.Core
{
    public interface IHttpResponse
    {
        Task ExecuteAsync();
    }
}