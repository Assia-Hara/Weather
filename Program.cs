using Microsoft.EntityFrameworkCore;
using MVC.data;
using Weather_React_DotNet_Project.Repositories;
using Weather_React_DotNet_Project.Repositories.Interfaces;
using Weather_React_DotNet_Project.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:44421")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

// Add services to the container.

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserPreferenceRepository, UserPreferenceRepository>();
builder.Services.AddScoped<UserPreferenceService>();
builder.Services.AddScoped<IWeatherDataRepository, WeatherDataRepository>();
builder.Services.AddScoped<WeatherDataService>();
builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
builder.Services.AddScoped<WeatherForecastService>();


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        options => options.EnableRetryOnFailure() // Optionally, you can configure retry policies here
    );
});

var app = builder.Build();
app.UseCors("AllowSpecificOrigin"); 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
