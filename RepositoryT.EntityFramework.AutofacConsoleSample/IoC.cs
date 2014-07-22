using Autofac;
using RepositoryT.EntityFramework.SimpleBusiness;
using RepositoryT.EntityFramework.SimpleBusiness.Repository;
using RepositoryT.EntityFramework.SimpleBusiness.Service;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.AutofacConsoleSample
{
    public static class IoC
    {
        private static readonly IContainer Container;
        static IoC()
        {
            var builder = new ContainerBuilder();

            builder.Register<IDataContextFactory<SampleDataContext>>(x => new DefaultDataContextFactory<SampleDataContext>()).InstancePerLifetimeScope();
            builder.Register<IUserRepository>(x => new UserRepository(x.Resolve<IDataContextFactory<SampleDataContext>>())).SingleInstance();
            builder.Register<IUnitOfWork>(x => new UnitOfWork<SampleDataContext>(x.Resolve<IDataContextFactory<SampleDataContext>>())).SingleInstance();
            builder.Register<IUserService>(x => new UserService(x.Resolve<IUnitOfWork>(), x.Resolve<IUserRepository>())).SingleInstance();
            Container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}