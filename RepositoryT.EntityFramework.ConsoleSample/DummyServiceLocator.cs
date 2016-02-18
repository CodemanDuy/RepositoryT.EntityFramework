using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using RepositoryT.EntityFramework.SimpleBusiness;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.ConsoleSample
{
    public class DummyServiceLocator : IServiceLocator
    {
        readonly ConcurrentDictionary<Type, object> _services;

        public DummyServiceLocator()
        {
            _services = new ConcurrentDictionary<Type, object>
            {
                [typeof (IDataContextFactory<SampleDataContext>)] = new DefaultDataContextFactory<SampleDataContext>()
            };
        } 
        public object GetService(Type serviceType)
        {
            return _services[serviceType];
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}