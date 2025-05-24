using Backend.Core.Services.VehicleRelated.ManufacturerServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.VehicleRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturerController : ControllerBase {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService) {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManufacturerEntity>>> GetAll() {
            var gps = await _manufacturerService.GetAllManufacturersAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerEntity>> GetById(int id) {
            var gps = await _manufacturerService.GetManufacturerByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<ManufacturerEntity>> Create([FromBody] CreateManufacturerDto dto) {
            var created = await _manufacturerService.CreateManufacturerAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.ManufacturerID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateManufacturerDto dto) {
            var success = await _manufacturerService.UpdateManufacturerAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _manufacturerService.DeleteManufacturerAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}