using System;
using System.Collections.Generic;
using System.Web.Http;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.WebApiIntegration
{
    public class WebApiDependencyResolverAdapter : IDependencyResolverAdapter
    {
        public object GetService(Type serviceType)
        {
            return GlobalConfiguration.Configuration.DependencyResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return GlobalConfiguration.Configuration.DependencyResolver.GetServices(serviceType);
        }
    }
}
