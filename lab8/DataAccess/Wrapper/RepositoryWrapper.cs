using Domain.Interfaces;
using Domain.SQL;
using DataAccess.Repositories;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : Domain.Wrapper.IRepositoryWrapper
    {
        private PracticaContext _repoContext;

        private IUserRepository _user;
        public IUserRepository UserRepository
        { 
            get 
            { 
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            } 
        }
        public RepositoryWrapper(PracticaContext repoContext)
        {
            _repoContext = repoContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
