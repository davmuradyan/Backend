using Backend.Core.Services.GpsRelated.GPSServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.GpsRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class GPSController : ControllerBase {
        private readonly IGPSService _gpsService;

        public GPSController(IGPSService gpsService) {
            _gpsService = gpsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GPSEntity>>> GetAll() {
            var gps = await _gpsService.GetAllGPSAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GPSEntity>> GetById(int id) {
            var gps = await _gpsService.GetGPSByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<GPSEntity>> Create([FromBody] CreateGPSDto dto) {
            var created = await _gpsService.CreateGPSAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.GpsID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGPSDto dto) {
            var success = await _gpsService.UpdateGPSAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _gpsService.DeleteGPSAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}