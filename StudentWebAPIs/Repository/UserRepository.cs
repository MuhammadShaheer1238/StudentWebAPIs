using Microsoft.EntityFrameworkCore;
using StudentWebAPIs.Data;
using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly StudentDbContext _dbContext;
        public UserRepository(StudentDbContext studentDbContext)
        {
            _dbContext = studentDbContext;
        }

        public async Task<User> AuthenticateUser(string username, string password)
        {
            var userExist = await _dbContext.users.FirstOrDefaultAsync(x => x.userName.ToLower().Trim() == username.ToLower().Trim() && x.Password == password);
            //if(userExist != null)
            //{
            //    var verifyPassword = await _dbContext.users.FirstOrDefaultAsync(x => x.Password.ToLower().Trim() == password.ToLower().Trim());
            //}
            
            var userRoles = await _dbContext.UserRoles.Where(x=> x.userId == userExist.Id).ToListAsync();
            if (userRoles.Any())
            {
                userExist.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await _dbContext.roles.FirstOrDefaultAsync(x => x.Id == userRole.roleId);
                    userExist.Roles.Add(role.roleName);
                }
            }

            userExist.Password = null;

            return userExist;
        }
    }
}
