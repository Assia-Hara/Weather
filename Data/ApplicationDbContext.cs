using Microsoft.EntityFrameworkCore;
using Weather_React_DotNet_Project.Models;

namespace MVC.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Location> Location { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserPreference> UserPreference { get; set; }
        public DbSet<WeatherData> WeatherData { get; set; }
        public DbSet<WeatherForecast> WeatherForecast { get; set; }
        public DbSet<WeatherType> WeatherType { get; set; }
    }
}
