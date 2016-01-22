using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework
{
    public class EfUnitOfWork<TContext> :UnitOfWorkBase<TContext> where TContext : class, IDisposable, IObjectContextAdapter
    {
        public EfUnitOfWork(IDependencyResolverAdapter resolver):base(resolver)
        {
        }

        protected ObjectContext ObjectContext
        {
            get { return DataContext.ObjectContext; }
        }

        protected ObjectStateManager ObjectStateManager
        {
            get { return ObjectContext.ObjectStateManager; }
        }

        public override void Commit()
        {
            if (DataContext != null)
            {
                var dbContext = DataContext as DbContext;
                if (dbContext != null) dbContext.SaveChanges();
            }
        }
    }
}
