using Microsoft.AspNetCore.Mvc;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather_React_DotNet_Project.Models.NewFolder;
using System.Text;

namespace Weather_React_DotNet_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDataController : ControllerBase
    {
        private readonly WeatherDataService _weatherDataService;

        public WeatherDataController(WeatherDataService weatherDataService)
        {
            _weatherDataService = weatherDataService;
        }

        // GET: api/WeatherData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherData>>> GetWeatherData()
        {
            var weatherData = await _weatherDataService.GetAllWeatherDataAsync();
            return Ok(weatherData);
        }

        // GET: api/WeatherData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherData>> GetWeatherData(int id)
        {
            var weatherData = await _weatherDataService.GetWeatherDataByIdAsync(id);

            if (weatherData == null)
            {
                return NotFound();
            }

            return Ok(weatherData);
        }

        // POST: api/WeatherData
        [HttpPost]
        public async Task<ActionResult<WeatherData>> PostWeatherData(WeatherData weatherData)
        {
            await _weatherDataService.AddWeatherDataAsync(weatherData);
            return CreatedAtAction(nameof(GetWeatherData), new { id = weatherData.DataID }, weatherData);
        }

        // PUT: api/WeatherData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherData(int id, WeatherData weatherData)
        {
            if (id != weatherData.DataID)
            {
                return BadRequest();
            }

            await _weatherDataService.UpdateWeatherDataAsync(weatherData);
            return NoContent();
        }

        // DELETE: api/WeatherData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherData(int id)
        {
            var weatherData = await _weatherDataService.GetWeatherDataByIdAsync(id);
            if (weatherData == null)
            {
                return NotFound();
            }

            await _weatherDataService.DeleteWeatherDataAsync(id);
            return NoContent();
        }
            // ... existing code ...

            [HttpGet("getWeatherByLocation/{latitude}/{longitude}")]
            public async Task<ActionResult<WeatherData>> GetWeatherByLocation(double latitude, double longitude)
            {
                var apiKey = "4c48f19b198c12bc5d08aecd1b97dca4";
                var url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}";

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStringAsync(url);
                    var apiResponse = JsonConvert.DeserializeObject<OpenWeatherResponse>(response);

                    var weatherData = new WeatherData
                    {
                        Date = DateTime.UtcNow.Date,
                        Time = DateTime.UtcNow.TimeOfDay,
                        Temperature = ConvertKelvinToCelsius(apiResponse.Main.Temp),
                        Humidity = apiResponse.Main.Humidity,
                        Pressure = apiResponse.Main.Pressure,
                        // Map other necessary fields
                    };

                    return Ok(weatherData);
                }
            }

		[HttpGet("getWeatherForecast/{latitude}/{longitude}")]
		public async Task<ActionResult<string>> GetWeatherForecast(double latitude, double longitude)
		{
			try
			{
				var apiKey = "4c48f19b198c12bc5d08aecd1b97dca4";
				var url = $"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&appid={apiKey}";

				using (var httpClient = new HttpClient())
				{
					var response = await httpClient.GetStringAsync(url);
					var apiResponse = JsonConvert.DeserializeObject<OpenWeatherForecastResponse>(response);

					// Format the next 7 days with each day's temperature
					var formattedForecast = FormatForecastData(apiResponse.List);

					return Ok(formattedForecast);
				}
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "Internal Server Error");
			}
		}

		private string FormatForecastData(List<ForecastItem> forecastItems)
		{
			// Assuming that the forecastItems are sorted by date
			var forecastStringBuilder = new StringBuilder();

			DateTime currentDate = DateTime.MinValue;

			foreach (var forecastItem in forecastItems)
			{
				// Extract date part only
				var forecastDate = forecastItem.DtTxt.Date;

				if (currentDate != forecastDate)
				{
					// Start a new line for each day
					if (currentDate != DateTime.MinValue)
					{
						forecastStringBuilder.AppendLine();
					}

					forecastStringBuilder.Append($"Date: {forecastDate.ToShortDateString()} - Temperatures: ");
					currentDate = forecastDate;
				}

				// Append temperature for the current time of day
				forecastStringBuilder.Append($"{forecastItem.Main.Temp}°C, ");
			}

			return forecastStringBuilder.ToString();
		}








		private decimal ConvertKelvinToCelsius(double kelvinTemp)
            {
                return (decimal)(kelvinTemp - 273.15);
            }
        }



    }

