using MVC.data;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Repositories.Interfaces;

namespace Weather_React_DotNet_Project.Repositories
{
    public class WeatherDataRepository : Repository<WeatherData>, IWeatherDataRepository
    {
        public WeatherDataRepository(AppDbContext context) : base(context)
        {
            // Additional implementation specific to WeatherData, if any
        }

        // Implement additional methods specific to WeatherData
    }

}
