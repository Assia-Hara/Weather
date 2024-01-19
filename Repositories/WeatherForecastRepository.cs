using MVC.data;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Repositories.Interfaces;
using Weather_React_DotNet_Project.Repositories;

namespace Weather_React_DotNet_Project.Repositories
{
    public class WeatherForecastRepository : Repository<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(AppDbContext context) : base(context)
        {
            // Additional implementation specific to WeatherForecast, if any
        }

        // Implement additional methods specific to WeatherForecast
    }

}
