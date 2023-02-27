
using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public interface IUserRepository
    {
        Task<User> AuthenticateUser(string username, string password);
    }
}
