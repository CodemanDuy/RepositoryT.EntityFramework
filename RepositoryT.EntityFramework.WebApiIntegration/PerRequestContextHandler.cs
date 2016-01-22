using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.WebApiIntegration
{
    public class PerRequestContextHandler : DelegatingHandler
    {
        private IContextManager ContextManager { get; set; }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            ContextManager = request.GetDependencyScope().GetService(typeof(IContextManager)) as IContextManager;

            if (ContextManager != null)
            {
                ContextManager.Create();
            }

            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                ContextManager = request.GetDependencyScope().GetService(typeof(IContextManager)) as IContextManager;

                if (ContextManager != null)
                {
                    ContextManager.Release();
                }

                return task.Result;
            }, cancellationToken);
        }
    }
}