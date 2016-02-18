RepositoryT.EntityFramework
========

Generic Repository and Pattern UnitOfWork implementation with base classes.

**sample repository**
```csharp
 public interface IUserRepository: IRepository <User> 
 {
 }

 public class UserRepository: EntityRepository <User, SampleDataContext> , IUserRepository 
 {
  public UserRepository(IServiceLocator serviceLocator): base(serviceLocator) {

  }
 }
```

**sample service**
```csharp
  public interface IUserService
  {
    int AddUser(User user);
    IEnumerable<User> GetAll();
  }
  
  public class UserService : IUserService
  {
   private readonly IUnitOfWork _unitOfWork;
   private readonly IUserRepository _userRepository;

   public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
   {
     _unitOfWork = unitOfWork;
     _userRepository = userRepository;
   }

    public int AddUser(User user)
    {
      _userRepository.Add(user);
      _unitOfWork.Commit();
      return user.Id;
    }

    public IEnumerable<User> GetAll()
    {
      return _userRepository.GetAll();
    }
  }
```

**sample autofac registrations**
```csharp
  var builder = new ContainerBuilder();

  builder.RegisterType<AutofacServiceLocator>().As<IServiceLocator>().SingleInstance();
  builder.RegisterType<DefaultDataContextFactory<SampleDataContext>>()
         .As<IDataContextFactory<SampleDataContext>>().InstancePerDependency();
  builder.RegisterType<EfUnitOfWork<SampleDataContext>>().As<IUnitOfWork>().SingleInstance();
  builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
  builder.RegisterType<UserService>().As<IUserService>().SingleInstance();

  container = builder.Build();
```

**NOTE :** To see more samples please look at code samples.
