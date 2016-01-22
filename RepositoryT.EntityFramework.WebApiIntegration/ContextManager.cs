using System;
using RepositoryT.EntityFramework.Interfaces;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.WebApiIntegration
{
    public class ContextManager<TContext> : IContextManager where TContext : IDbContext, IDisposable
    {
        private readonly IDataContextFactory<TContext> _contextFactory;

        public ContextManager(IDataContextFactory<TContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Create()
        {
            _contextFactory.Create();
        }

        public void Release()
        {
            _contextFactory.Release();
        }
    }
}