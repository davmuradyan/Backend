using Microsoft.AspNetCore.Mvc;
using Backend.Core.Services.GpsRelated.GNSSSystemServices;
using Backend.Data.Entities;

namespace Backend.Controllers.GpsRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class GNSSSystemController : ControllerBase {
        private readonly IGNSSSystemService _gnssService;

        public GNSSSystemController(IGNSSSystemService gnssService) {
            _gnssService = gnssService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GNSSSystemEntity>>> GetAll() {
            var systems = await _gnssService.GetAllGNSSSystemsAsync();
            return Ok(systems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GNSSSystemEntity>> GetById(int id) {
            var system = await _gnssService.GetGNSSSystemByIdAsync(id);
            if (system == null)
                return NotFound();
            return Ok(system);
        }

        [HttpPost]
        public async Task<ActionResult<GNSSSystemEntity>> Create([FromBody] CreateGNSSSystemDto dto) {
            var created = await _gnssService.CreateGNSSSystemAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.GNSSSystemID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGNSSSystemDto dto) {
            var success = await _gnssService.UpdateGNSSSystemAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _gnssService.DeleteGNSSSystemAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}