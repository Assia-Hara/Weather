using MVC.data;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Repositories.Interfaces;

namespace Weather_React_DotNet_Project.Repositories
{
    public class UserPreferenceRepository : Repository<UserPreference>, IUserPreferenceRepository
    {
        public UserPreferenceRepository(AppDbContext context) : base(context)
        {
            // Additional implementation specific to UserPreference, if any
        }

        // Implement additional methods specific to UserPreference
    }

}
