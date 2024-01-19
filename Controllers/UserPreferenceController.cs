using Microsoft.AspNetCore.Mvc;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Weather_React_DotNet_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPreferenceController : ControllerBase
    {
        private readonly UserPreferenceService _userPreferenceService;

        public UserPreferenceController(UserPreferenceService userPreferenceService)
        {
            _userPreferenceService = userPreferenceService;
        }

        // GET: api/UserPreference
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPreference>>> GetUserPreferences()
        {
            var userPreferences = await _userPreferenceService.GetAllUserPreferencesAsync();
            return Ok(userPreferences);
        }

        // GET: api/UserPreference/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPreference>> GetUserPreference(int id)
        {
            var userPreference = await _userPreferenceService.GetUserPreferenceByIdAsync(id);

            if (userPreference == null)
            {
                return NotFound();
            }

            return Ok(userPreference);
        }

        // POST: api/UserPreference
        [HttpPost]
        public async Task<ActionResult<UserPreference>> PostUserPreference(UserPreference userPreference)
        {
            await _userPreferenceService.AddUserPreferenceAsync(userPreference);
            return CreatedAtAction(nameof(GetUserPreference), new { id = userPreference.PreferenceID }, userPreference);
        }

        // PUT: api/UserPreference/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPreference(int id, UserPreference userPreference)
        {
            if (id != userPreference.PreferenceID)
            {
                return BadRequest();
            }

            await _userPreferenceService.UpdateUserPreferenceAsync(userPreference);
            return NoContent();
        }

        // DELETE: api/UserPreference/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPreference(int id)
        {
            var userPreference = await _userPreferenceService.GetUserPreferenceByIdAsync(id);
            if (userPreference == null)
            {
                return NotFound();
            }

            await _userPreferenceService.DeleteUserPreferenceAsync(id);
            return NoContent();
        }
    }
}
