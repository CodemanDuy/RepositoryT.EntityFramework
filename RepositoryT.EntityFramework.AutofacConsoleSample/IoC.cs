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

            builder.RegisterType<AutofacServiceLocator>().As<IServiceLocator>().SingleInstance();

            builder.RegisterType<DefaultDataContextFactory<SampleDataContext>>().As<IDataContextFactory<SampleDataContext>>().InstancePerLifetimeScope();
            builder.RegisterType<EfUnitOfWork<SampleDataContext>>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();


            Container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}