using Microsoft.AspNetCore.Mvc;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Weather_React_DotNet_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherTypeController : ControllerBase
    {
        private readonly WeatherTypeService _weatherTypeService;

        public WeatherTypeController(WeatherTypeService weatherTypeService)
        {
            _weatherTypeService = weatherTypeService;
        }

        // GET: api/WeatherType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherType>>> GetWeatherTypes()
        {
            var weatherTypes = await _weatherTypeService.GetAllWeatherTypesAsync();
            return Ok(weatherTypes);
        }

        // GET: api/WeatherType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherType>> GetWeatherType(int id)
        {
            var weatherType = await _weatherTypeService.GetWeatherTypeByIdAsync(id);

            if (weatherType == null)
            {
                return NotFound();
            }

            return Ok(weatherType);
        }

        // POST: api/WeatherType
        [HttpPost]
        public async Task<ActionResult<WeatherType>> PostWeatherType(WeatherType weatherType)
        {
            await _weatherTypeService.AddWeatherTypeAsync(weatherType);
            return CreatedAtAction(nameof(GetWeatherType), new { id = weatherType.TypeID }, weatherType);
        }

        // PUT: api/WeatherType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherType(int id, WeatherType weatherType)
        {
            if (id != weatherType.TypeID)
            {
                return BadRequest();
            }

            await _weatherTypeService.UpdateWeatherTypeAsync(weatherType);
            return NoContent();
        }

        // DELETE: api/WeatherType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherType(int id)
        {
            var weatherType = await _weatherTypeService.GetWeatherTypeByIdAsync(id);
            if (weatherType == null)
            {
                return NotFound();
            }

            await _weatherTypeService.DeleteWeatherTypeAsync(id);
            return NoContent();
        }
    }
}
