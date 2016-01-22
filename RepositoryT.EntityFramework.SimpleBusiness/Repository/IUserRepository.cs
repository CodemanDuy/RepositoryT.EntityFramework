using RepositoryT.EntityFramework.Interfaces;
using RepositoryT.EntityFramework.SimpleBusiness.Entities;

namespace RepositoryT.EntityFramework.SimpleBusiness.Repository
{
    public interface IUserRepository : IEfRepository<User>
    {
    }
}