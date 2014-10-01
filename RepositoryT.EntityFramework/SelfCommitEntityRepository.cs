using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework
{
    public class SelfCommitEntityRepository<T, TContext> : EntityRepository<T, TContext>
        where T : class
        where TContext : class, IDbContext, IDisposable
    {
        private readonly IDbSet<T> _dbset;

        public SelfCommitEntityRepository(IDataContextFactory<TContext> databaseFactory)
            : base(databaseFactory)
        {
            _dbset = DataContext.Set<T>();
        }

        public override void Add(T entity)
        {
            _dbset.Add(entity);
            SaveChanges();
        }

        public override void Add(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _dbset.Add(entity);
            }
            SaveChanges();
        }

        public override void Update(T entity)
        {
            _dbset.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public override void Delete(T entity)
        {
            _dbset.Remove(entity);
            SaveChanges();
        }

        public override void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where(@where).AsEnumerable();
            foreach (T obj in objects)
                _dbset.Remove(obj);
            SaveChanges();
        }

        private void SaveChanges()
        {
            var dbContext = DataContext as DbContext;
            if (dbContext != null) dbContext.SaveChanges();
        }
    }
}