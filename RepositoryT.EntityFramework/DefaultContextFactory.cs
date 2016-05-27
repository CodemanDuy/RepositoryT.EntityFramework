using System;
using RepositoryT.EntityFramework.Interfaces;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework
{
    public class DefaultDataContextFactory<TContext> : IDataContextFactory<TContext> where TContext : class,IDbContext, IDisposable, new()
    {
        private TContext _dataContext;

        public TContext GetContext()
        {
            return _dataContext ?? (_dataContext = new TContext());
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}