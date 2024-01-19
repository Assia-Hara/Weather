using Microsoft.EntityFrameworkCore;
using MVC.data;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Repositories.Interfaces;

namespace Weather_React_DotNet_Project.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;

        public UserService(IUserRepository userRepository, AppDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _userRepository.Update(user);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
            await _userRepository.SaveAsync();
        }
        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var user = await _context.User
                                     .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            return user;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.User
                                 .FirstOrDefaultAsync(u => u.Username == username);
        }


    }

}
