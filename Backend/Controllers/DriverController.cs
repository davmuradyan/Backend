using Microsoft.AspNetCore.Mvc;
using Backend.Core.Services.DriverServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using Backend.Data.Entities;

namespace Backend.Controllers {
    [ApiController]
    [Route("api/drivers")]
    public class DriverController : ControllerBase {
        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService) {
            this.driverService = driverService;
        }

        /// <summary>
        /// Creates a new Driver.
        /// </summary>
        [HttpPost("AddDriver")]
        public async Task<IActionResult> AddDriver(string name, string surname, int? busId) {
            var driver = await driverService.CreateDriverAsync(name, surname, busId);
            return Ok(driver);
        }

        /// <summary>
        /// Retrieves a Driver by ID.
        /// </summary>
        [HttpGet("GetDriver/{id}")]
        public async Task<IActionResult> GetDriver(int id) {
            var driver = await driverService.GetDriverAsync(id);
            return driver != null ? Ok(driver) : NotFound();
        }

        /// <summary>
        /// Retrieves all Drivers.
        /// </summary>
        [HttpGet("GetDrivers")]
        public async Task<IActionResult> GetDrivers() {
            var drivers = await driverService.GetDriversAsync();
            return Ok(drivers);
        }

        /// <summary>
        /// Updates an existing Driver.
        /// </summary>
        [HttpPut("UpdateDriver/{id}")]
        public async Task<IActionResult> UpdateDriver(int id, [FromBody] UpdateDriverRequest request) {
            var updatedDriver = await driverService.UpdateDriverAsync(id, request.Name, request.Surname, request.BusId);
            return updatedDriver != null ? Ok(updatedDriver) : NotFound();
        }

        /// <summary>
        /// Deletes a Driver.
        /// </summary>
        [HttpDelete("DeleteDriver/{id}")]
        public async Task<IActionResult> DeleteDriver(int id) {
            var result = await driverService.DeleteDriverAsync(id);
            return result ? NoContent() : NotFound();
        }
    }

    /// <summary>
    /// DTO for updating a Driver.
    /// </summary>
    public class UpdateDriverRequest {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? BusId { get; set; }
    }
}