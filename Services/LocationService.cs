namespace Weather_React_DotNet_Project.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Weather_React_DotNet_Project.Models;
    using Weather_React_DotNet_Project.Repositories.Interfaces;

    public class LocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _locationRepository.GetAllAsync();
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _locationRepository.GetByIdAsync(id);
        }

        public async Task AddLocationAsync(Location location)
        {
            await _locationRepository.AddAsync(location);
            await _locationRepository.SaveAsync();
        }

        public async Task UpdateLocationAsync(Location location)
        {
            _locationRepository.Update(location);
            await _locationRepository.SaveAsync();
        }

        public async Task DeleteLocationAsync(int id)
        {
            await _locationRepository.DeleteAsync(id);
            await _locationRepository.SaveAsync();
        }
    }

}
