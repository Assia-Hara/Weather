using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Repositories.Interfaces;

namespace Weather_React_DotNet_Project.Services
{
    public class WeatherTypeService
    {
        private readonly IWeatherTypeRepository _weatherTypeRepository;

        public WeatherTypeService(IWeatherTypeRepository weatherTypeRepository)
        {
            _weatherTypeRepository = weatherTypeRepository;
        }

        public async Task<IEnumerable<WeatherType>> GetAllWeatherTypesAsync()
        {
            return await _weatherTypeRepository.GetAllAsync();
        }

        public async Task<WeatherType> GetWeatherTypeByIdAsync(int id)
        {
            return await _weatherTypeRepository.GetByIdAsync(id);
        }

        public async Task AddWeatherTypeAsync(WeatherType weatherType)
        {
            await _weatherTypeRepository.AddAsync(weatherType);
            await _weatherTypeRepository.SaveAsync();
        }

        public async Task UpdateWeatherTypeAsync(WeatherType weatherType)
        {
            _weatherTypeRepository.Update(weatherType);
            await _weatherTypeRepository.SaveAsync();
        }

        public async Task DeleteWeatherTypeAsync(int id)
        {
            await _weatherTypeRepository.DeleteAsync(id);
            await _weatherTypeRepository.SaveAsync();
        }
    }

}
