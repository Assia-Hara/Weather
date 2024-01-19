using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Repositories.Interfaces;

namespace Weather_React_DotNet_Project.Services
{
    public class WeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllWeatherForecastsAsync()
        {
            return await _weatherForecastRepository.GetAllAsync();
        }

        public async Task<WeatherForecast> GetWeatherForecastByIdAsync(int id)
        {
            return await _weatherForecastRepository.GetByIdAsync(id);
        }

        public async Task AddWeatherForecastAsync(WeatherForecast weatherForecast)
        {
            await _weatherForecastRepository.AddAsync(weatherForecast);
            await _weatherForecastRepository.SaveAsync();
        }

        public async Task UpdateWeatherForecastAsync(WeatherForecast weatherForecast)
        {
            _weatherForecastRepository.Update(weatherForecast);
            await _weatherForecastRepository.SaveAsync();
        }

        public async Task DeleteWeatherForecastAsync(int id)
        {
            await _weatherForecastRepository.DeleteAsync(id);
            await _weatherForecastRepository.SaveAsync();
        }
    }

}
