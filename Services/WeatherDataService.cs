using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Repositories.Interfaces;

namespace Weather_React_DotNet_Project.Services
{
    public class WeatherDataService
    {
        private readonly IWeatherDataRepository _weatherDataRepository;

        public WeatherDataService(IWeatherDataRepository weatherDataRepository)
        {
            _weatherDataRepository = weatherDataRepository;
        }

        public async Task<IEnumerable<WeatherData>> GetAllWeatherDataAsync()
        {
            return await _weatherDataRepository.GetAllAsync();
        }

        public async Task<WeatherData> GetWeatherDataByIdAsync(int id)
        {
            return await _weatherDataRepository.GetByIdAsync(id);
        }

        public async Task AddWeatherDataAsync(WeatherData weatherData)
        {
            await _weatherDataRepository.AddAsync(weatherData);
            await _weatherDataRepository.SaveAsync();
        }

        public async Task UpdateWeatherDataAsync(WeatherData weatherData)
        {
            _weatherDataRepository.Update(weatherData);
            await _weatherDataRepository.SaveAsync();
        }

        public async Task DeleteWeatherDataAsync(int id)
        {
            await _weatherDataRepository.DeleteAsync(id);
            await _weatherDataRepository.SaveAsync();
        }


    }

}
