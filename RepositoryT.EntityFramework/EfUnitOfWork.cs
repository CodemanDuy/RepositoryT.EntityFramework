using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework
{
    public class EfUnitOfWork<TContext> :UnitOfWorkBase<TContext> where TContext : class, IDisposable, IObjectContextAdapter
    {
        public EfUnitOfWork(IServiceLocator serviceLocator):base(serviceLocator)
        {
        }

        protected ObjectContext ObjectContext => DataContext.ObjectContext;

        protected ObjectStateManager ObjectStateManager => ObjectContext.ObjectStateManager;

        public override void Commit()
        {
            var dbContext = DataContext as DbContext;
            dbContext?.SaveChanges();
        }
    }
}
