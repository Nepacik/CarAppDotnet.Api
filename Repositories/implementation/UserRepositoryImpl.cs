using System.Linq;
using System.Net;
using CarAppDotNetApi.Data;
using CarAppDotNetApi.ErrorHandling;
using CarAppDotNetApi.Models;
using CarAppDotNetApi.Repositories.BaseRepositories;

namespace CarAppDotNetApi.Repositories.implementation
{
    public class UserRepositoryImpl : BaseRepository<User>, IUserRepository
    {
        
        public UserRepositoryImpl(AppDbContext context) : base(context)
        {
        }

        public void CreateUser(User user)
        {
            if (GetUserByUserName(user.Username) != null)
            {
                throw new AppException(HttpStatusCode.Conflict, "USERNAME_ALREADY_EXISTS");
            }
            _dbSet.Add(user);
            SaveChanges();
        }

        public User GetUserByUserName(string userName)
        {
            return _dbSet.SingleOrDefault(user => user.Username == userName);
        }

    }
}