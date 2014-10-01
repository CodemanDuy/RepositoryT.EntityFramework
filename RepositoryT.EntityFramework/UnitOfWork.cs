using System;
using System.Data.Entity;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework
{
    public class UnitOfWork<TContext> : UnitOfWorkBase<TContext> where TContext : class ,IDbContext, IDisposable, new()
    {

        public UnitOfWork(IDataContextFactory<TContext> databaseFactory)
            : base(databaseFactory)
        {

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
