using MVC.data;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Repositories.Interfaces;

namespace Weather_React_DotNet_Project.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
            // Additional implementation specific to User, if any
        }

        // Implement additional methods specific to the User entity
    }

}
