using Microsoft.AspNetCore.Mvc;
using Backend.Core.Services.GpsRelated.GpsModelGNSSServices;
using Backend.Data.Entities;

namespace Backend.Controllers.GpsRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class GpsModelGNSSController : ControllerBase {
        private readonly IGpsModelGNSSService _gpsModelGnssService;

        public GpsModelGNSSController(IGpsModelGNSSService gpsModelGnssService) {
            _gpsModelGnssService = gpsModelGnssService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GpsModelGNSSEntity>>> GetAll() {
            var models = await _gpsModelGnssService.GetAllLinksAsync();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GpsModelGNSSEntity>> GetById(int id) {
            var model = await _gpsModelGnssService.GetLinkByIdAsync(id);
            if (model == null) return NotFound();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<GpsModelGNSSEntity>> Create([FromBody] CreateGpsModelGNSSDto dto) {
            var created = await _gpsModelGnssService.CreateLinkAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.GNSSSystemID }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _gpsModelGnssService.DeleteLinkAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}