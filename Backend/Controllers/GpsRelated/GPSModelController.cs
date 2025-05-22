using Backend.Core.Services.GpsRelated.GPSModelServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.GpsRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class GPSModelController : ControllerBase {
        private readonly IGPSModelService _gpsModelService;

        public GPSModelController(IGPSModelService gpsModelService) {
            _gpsModelService = gpsModelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GPSModelEntity>>> GetAll() {
            var models = await _gpsModelService.GetAllGPSModelsAsync();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GPSModelEntity>> GetById(int id) {
            var system = await _gpsModelService.GetGPSModelByIdAsync(id);
            if (system == null)
                return NotFound();
            return Ok(system);
        }

        [HttpPost]
        public async Task<ActionResult<GPSModelEntity>> Create([FromBody] CreateGPSModelDto dto) {
            var created = await _gpsModelService.CreateGPSModelAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.GPSModelID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGPSModelDto dto) {
            var success = await _gpsModelService.UpdateGPSModelAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _gpsModelService.DeleteGPSModelAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}