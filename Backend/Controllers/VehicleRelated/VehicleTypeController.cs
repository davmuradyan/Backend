using Backend.Core.Services.VehicleRelated.VehicleTypeServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.VehicleRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleTypeController : ControllerBase {
        private readonly IVehicleTypeService _vehicleTypeService;

        public VehicleTypeController(IVehicleTypeService vehicleTypeService) {
            _vehicleTypeService = vehicleTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleTypeEntity>>> GetAll() {
            var gps = await _vehicleTypeService.GetAllVehicleTypesAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleTypeEntity>> GetById(int id) {
            var gps = await _vehicleTypeService.GetVehicleTypeByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleTypeEntity>> Create([FromBody] CreateVehicleTypeDto dto) {
            var created = await _vehicleTypeService.CreateVehicleTypeAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.VehicleTypeID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateVehicleTypeDto dto) {
            var success = await _vehicleTypeService.UpdateVehicleTypeAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _vehicleTypeService.DeleteVehicleTypeAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}