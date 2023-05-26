using DataAccess.Interfaces;
using Domain.SQL;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, Domain.Interfaces.IUserRepository
    {
        public UserRepository(PracticaContext repositoryContext) : base(repositoryContext)
        {
        }

    }
}
