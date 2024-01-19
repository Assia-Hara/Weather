using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Repositories.Interfaces;

namespace Weather_React_DotNet_Project.Services
{
    public class UserPreferenceService
    {
        private readonly IUserPreferenceRepository _userPreferenceRepository;

        public UserPreferenceService(IUserPreferenceRepository userPreferenceRepository)
        {
            _userPreferenceRepository = userPreferenceRepository;
        }

        public async Task<IEnumerable<UserPreference>> GetAllUserPreferencesAsync()
        {
            return await _userPreferenceRepository.GetAllAsync();
        }

        public async Task<UserPreference> GetUserPreferenceByIdAsync(int id)
        {
            return await _userPreferenceRepository.GetByIdAsync(id);
        }

        public async Task AddUserPreferenceAsync(UserPreference userPreference)
        {
            await _userPreferenceRepository.AddAsync(userPreference);
            await _userPreferenceRepository.SaveAsync();
        }

        public async Task UpdateUserPreferenceAsync(UserPreference userPreference)
        {
            _userPreferenceRepository.Update(userPreference);
            await _userPreferenceRepository.SaveAsync();
        }

        public async Task DeleteUserPreferenceAsync(int id)
        {
            await _userPreferenceRepository.DeleteAsync(id);
            await _userPreferenceRepository.SaveAsync();
        }
    }

}
