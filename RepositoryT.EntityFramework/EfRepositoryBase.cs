using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using RepositoryT.EntityFramework.Interfaces;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework
{
    public class EfRepositoryBase<TContext> : RepositoryBase<TContext> where TContext : class, IDbContext, IDisposable
    {
        public EfRepositoryBase(IDependencyResolverAdapter resolver) : base(resolver)
        {
        }

        protected IDbSet<T> Set<T>() where T : class
        {
            return DataContext.Set<T>();
        }

        protected ObjectContext ObjectContextWrapper
        {
            get
            {
                return DataContext.ObjectContext;
            }
        }
    }
}