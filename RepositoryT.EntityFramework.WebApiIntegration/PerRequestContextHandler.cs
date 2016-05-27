using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.WebApiIntegration
{
    public class PerRequestContextHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var contextManager = request.GetDependencyScope().GetService(typeof(IContextManager)) as IContextManager;

            if (contextManager != null)
                request.RegisterForDispose(contextManager);

            return base.SendAsync(request, cancellationToken);
        }
    }
}