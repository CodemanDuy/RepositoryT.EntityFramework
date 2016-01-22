using System;
using RepositoryT.EntityFramework.Interfaces;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework
{
    public class DefaultDataContextFactory<TContext> : IDataContextFactory<TContext> where TContext : class,IDbContext, IDisposable, new()
    {
        private TContext _dataContext;

        #region IDatabaseFactory Members

        public TContext GetContext()
        {
            return _dataContext ?? (_dataContext = new TContext());
        }
        public void Create()
        {
            _dataContext = new TContext();
        }

        public void Release()
        {
            Dispose();
        }
        #endregion

        public void Dispose()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}