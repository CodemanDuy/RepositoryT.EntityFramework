using System;
using System.Collections.Generic;
using Autofac;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.AutofacConsoleSample
{
    public class AutofacDependencyResolverAdapter : IDependencyResolverAdapter
    {
        private readonly IComponentContext _container;
       

        public AutofacDependencyResolverAdapter(IComponentContext container)
        {
            _container = container;
           
        }

        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var enumerableServiceType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            var instance = _container.Resolve(enumerableServiceType);

            return (IEnumerable<object>)instance;
        }
    }
}