using Microsoft.AspNetCore.Mvc;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Weather_React_DotNet_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/Location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            return Ok(locations);
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // POST: api/Location
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            await _locationService.AddLocationAsync(location);
            return CreatedAtAction(nameof(GetLocation), new { id = location.LocationID }, location);
        }

        // PUT: api/Location/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            if (id != location.LocationID)
            {
                return BadRequest();
            }

            await _locationService.UpdateLocationAsync(location);
            return NoContent();
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            await _locationService.DeleteLocationAsync(id);
            return NoContent();
        }
    }
}
