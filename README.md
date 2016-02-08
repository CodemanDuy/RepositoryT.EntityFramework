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
  public UserRepository(IDependencyResolverAdapter resolver): base(resolver) {

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

**[To see sample autofac registrations](https://github.com/ziyasal/RepositoryT.EntityFramework/blob/master/RepositoryT.EntityFramework.AutofacConsoleSample/IoC.cs)**

**NOTE :** To see more samples please look at code samples.
