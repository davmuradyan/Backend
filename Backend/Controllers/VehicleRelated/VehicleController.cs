using Backend.Core.Services.VehicleRelated.VehicleServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.VehicleRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService) {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleEntity>>> GetAll() {
            var gps = await _vehicleService.GetAllVehiclesAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleEntity>> GetById(int id) {
            var gps = await _vehicleService.GetVehicleByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleEntity>> Create([FromBody] CreateVehicleDto dto) {
            var created = await _vehicleService.CreateVehicleAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.VehicleID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateVehicleDto dto) {
            var success = await _vehicleService.UpdateVehicleAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _vehicleService.DeleteVehicleAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}