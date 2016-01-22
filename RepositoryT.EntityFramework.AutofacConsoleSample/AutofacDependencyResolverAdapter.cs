using System;
using System.Collections.Generic;
using Autofac;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.AutofacConsoleSample
{
    public class AutofacDependencyResolverAdapter : IDependencyResolverAdapter
    {
        private readonly ILifetimeScope _scope;
       
        public AutofacDependencyResolverAdapter(ILifetimeScope scope)
        {
            _scope = scope;
           
        }

        public object GetService(Type serviceType)
        {
            return _scope.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var enumerableServiceType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            var instance = _scope.Resolve(enumerableServiceType);

            return (IEnumerable<object>)instance;
        }
    }
}