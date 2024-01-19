using MVC.data;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Repositories.Interfaces;

namespace Weather_React_DotNet_Project.Repositories
{
    public class WeatherTypeRepository : Repository<WeatherType>, IWeatherTypeRepository
    {
        public WeatherTypeRepository(AppDbContext context) : base(context)
        {
            // Additional implementation specific to WeatherType, if any
        }

        // Implement additional methods specific to WeatherType
    }

}
