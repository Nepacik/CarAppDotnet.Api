using CarAppDotNetApi.Models;
using CarAppDotNetApi.Repositories.BaseRepositories;

namespace CarAppDotNetApi.Repositories
{
    public interface IUserRepository
    {
        public void CreateUser(User user);

        public User GetUserByUserName(string userName);
    }
}