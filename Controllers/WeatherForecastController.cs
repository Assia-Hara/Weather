using Microsoft.AspNetCore.Mvc;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Weather_React_DotNet_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _weatherForecastService;

        public WeatherForecastController(WeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        // GET: api/WeatherForecast
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecasts()
        {
            var weatherForecasts = await _weatherForecastService.GetAllWeatherForecastsAsync();
            return Ok(weatherForecasts);
        }

        // GET: api/WeatherForecast/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(int id)
        {
            var weatherForecast = await _weatherForecastService.GetWeatherForecastByIdAsync(id);

            if (weatherForecast == null)
            {
                return NotFound();
            }

            return Ok(weatherForecast);
        }

        // POST: api/WeatherForecast
        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> PostWeatherForecast(WeatherForecast weatherForecast)
        {
            await _weatherForecastService.AddWeatherForecastAsync(weatherForecast);
            return CreatedAtAction(nameof(GetWeatherForecast), new { id = weatherForecast.ForecastID }, weatherForecast);

        }

        // PUT: api/WeatherForecast/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherForecast(int id, WeatherForecast weatherForecast)
        {
            if (id != weatherForecast.ForecastID)
            {
                return BadRequest();
            }

            await _weatherForecastService.UpdateWeatherForecastAsync(weatherForecast);
            return NoContent();
        }

        // DELETE: api/WeatherForecast/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherForecast(int id)
        {
            var weatherForecast = await _weatherForecastService.GetWeatherForecastByIdAsync(id);
            if (weatherForecast == null)
            {
                return NotFound();
            }

            await _weatherForecastService.DeleteWeatherForecastAsync(id);
            return NoContent();
        }
    }
}
