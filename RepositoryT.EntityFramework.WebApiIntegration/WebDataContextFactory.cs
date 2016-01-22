using System;
using System.Web;
using RepositoryT.EntityFramework.Interfaces;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.WebApiIntegration
{
    public class WebDataContextFactory<TContext> : IDataContextFactory<TContext> where TContext : class, IDbContext, IDisposable, new()
    {
        private const string CONTEXT_KEY = "___REPOSITORY_T_EF_CONTEXT_HTTP_KEY";

        public TContext GetContext()
        {
            TContext dataContext = null;
            if (HttpContext.Current != null)
            {
                if (!HttpContext.Current.Items.Contains(CONTEXT_KEY))
                {
                    HttpContext.Current.Items[CONTEXT_KEY] = new TContext();
                }
                else
                {
                    dataContext = (TContext)HttpContext.Current.Items[CONTEXT_KEY];

                    if (dataContext == null)
                    {
                        dataContext = new TContext();
                        HttpContext.Current.Items[CONTEXT_KEY] = dataContext;
                    }
                }
            }
            else
            {
                dataContext = new TContext();
            }

            return dataContext;
        }

        public void Create()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[CONTEXT_KEY] = new TContext();
            }
        }

        public void Release()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items.Contains(CONTEXT_KEY))
                {
                    TContext context = (TContext)HttpContext.Current.Items[CONTEXT_KEY];

                    if (context != null)
                    {
                        context.Dispose();
                    }

                    HttpContext.Current.Items.Remove(CONTEXT_KEY);
                }
            }
        }
    }
}