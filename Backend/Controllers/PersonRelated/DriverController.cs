using Backend.Core.Services.PersonRelated.DriverServices.Driver;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.PersonRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService) {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverEntity>>> GetAll() {
            var gps = await _driverService.GetAllDriversAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DriverEntity>> GetById(int id) {
            var gps = await _driverService.GetDriverByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<DriverEntity>> Create([FromBody] CreateDriverDto dto) {
            var created = await _driverService.CreateDriverAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.DriverID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDriverDto dto) {
            var success = await _driverService.UpdateDriverAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _driverService.DeleteDriverAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}