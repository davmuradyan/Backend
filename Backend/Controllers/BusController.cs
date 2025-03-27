using Microsoft.AspNetCore.Mvc;
using Backend.Core.Services.BusServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using Backend.Data.Entities;

namespace Backend.Controllers {
    [ApiController]
    [Route("api/buses")]
    public class BusController : ControllerBase {
        private readonly IBusService busService;

        public BusController(IBusService busService) {
            this.busService = busService;
        }

        /// <summary>
        /// Creates a new Bus.
        /// </summary>
        [HttpPost("AddBus")]
        public async Task<IActionResult> AddBus([FromBody] CreateBusRequest request) {
            var bus = await busService.CreateBusAsync(request.Model, request.CapacityStanding, request.CapacitySitting, request.RouteId, request.LicensePlate);
            return CreatedAtAction(nameof(GetBus), new { id = bus.Bus_id }, bus);
        }

        /// <summary>
        /// Retrieves a Bus by ID.
        /// </summary>
        [HttpGet("GetBus/{id}")]
        public async Task<IActionResult> GetBus(int id) {
            var bus = await busService.GetBusAsync(id);
            return bus != null ? Ok(bus) : NotFound();
        }

        /// <summary>
        /// Retrieves all Buses.
        /// </summary>
        [HttpGet("GetBuses")]
        public async Task<IActionResult> GetBuses() {
            var buses = await busService.GetBusesAsync();
            return Ok(buses);
        }

        /// <summary>
        /// Updates an existing Bus.
        /// </summary>
        [HttpPut("UpdateBus/{id}")]
        public async Task<IActionResult> UpdateBus(int id, [FromBody] UpdateBusRequest request) {
            var updatedBus = await busService.UpdateBusAsync(id, request.Model, request.CapacityStanding, request.CapacitySitting, request.RouteId, request.LicensePlate);
            return updatedBus != null ? Ok(updatedBus) : NotFound();
        }

        /// <summary>
        /// Deletes a Bus.
        /// </summary>
        [HttpDelete("DeleteBus/{id}")]
        public async Task<IActionResult> DeleteBus(int id) {
            var result = await busService.DeleteBusAsync(id);
            return result ? NoContent() : NotFound();
        }
    }

    /// <summary>
    /// DTO for creating a Bus.
    /// </summary>
    public class CreateBusRequest {
        public string Model { get; set; }
        public int CapacityStanding { get; set; }
        public int CapacitySitting { get; set; }
        public int? RouteId { get; set; }
        public string LicensePlate { get; set; }
    }

    /// <summary>
    /// DTO for updating a Bus.
    /// </summary>
    public class UpdateBusRequest {
        public string? Model { get; set; }
        public int? CapacityStanding { get; set; }
        public int? CapacitySitting { get; set; }
        public int? RouteId { get; set; }
        public string? LicensePlate { get; set; }
    }
}