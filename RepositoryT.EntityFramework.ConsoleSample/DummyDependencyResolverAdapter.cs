using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using RepositoryT.EntityFramework.SimpleBusiness;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.ConsoleSample
{
    public class DummyDependencyResolverAdapter : IDependencyResolverAdapter
    {
        readonly ConcurrentDictionary<Type, object> _dictionary;

        public DummyDependencyResolverAdapter()
        {
            _dictionary = new ConcurrentDictionary<Type, object>
            {
                [typeof (IDataContextFactory<SampleDataContext>)] = new DefaultDataContextFactory<SampleDataContext>()
            };
        } 
        public object GetService(Type serviceType)
        {
            return _dictionary[serviceType];
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}