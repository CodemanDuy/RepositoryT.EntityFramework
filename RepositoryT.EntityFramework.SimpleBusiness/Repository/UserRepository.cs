using RepositoryT.EntityFramework.SimpleBusiness.Entities;
using RepositoryT.Infrastructure;

namespace RepositoryT.EntityFramework.SimpleBusiness.Repository
{
    public class UserRepository : EntityRepository<User, SampleDataContext>, IUserRepository
    {
        public UserRepository(IDataContextFactory<SampleDataContext> databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}