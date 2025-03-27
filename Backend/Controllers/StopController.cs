using Microsoft.AspNetCore.Mvc;
using Backend.Core.Services.StopServices;
using Backend.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers {
    [ApiController]
    [Route("api/stops")]
    public class StopController : ControllerBase {
        private readonly IStopService stopService;

        public StopController(IStopService stopService) {
            this.stopService = stopService;
        }

        /// <summary>
        /// Creates a new Stop.
        /// </summary>
        [HttpPost("AddStop")]
        public async Task<IActionResult> AddStop([FromBody] CreateStopRequest request) {
            var stop = await stopService.CreateStopAsync(request.Name, request.Latitude, request.Longitude);
            return CreatedAtAction(nameof(GetStop), new { id = stop.Stop_id }, stop);
        }

        /// <summary>
        /// Retrieves a Stop by ID.
        /// </summary>
        [HttpGet("GetStop/{id}")]
        public async Task<IActionResult> GetStop(int id) {
            var stop = await stopService.GetStopAsync(id);
            return stop != null ? Ok(stop) : NotFound();
        }

        /// <summary>
        /// Retrieves all Stops.
        /// </summary>
        [HttpGet("GetStops")]
        public async Task<IActionResult> GetStops() {
            var stops = await stopService.GetStopsAsync();
            return Ok(stops);
        }

        /// <summary>
        /// Updates an existing Stop.
        /// </summary>
        [HttpPut("UpdateStop/{id}")]
        public async Task<IActionResult> UpdateStop(int id, [FromBody] UpdateStopRequest request) {
            var updatedStop = await stopService.UpdateStopAsync(id, request.Name, request.Latitude, request.Longitude);
            return updatedStop != null ? Ok(updatedStop) : NotFound();
        }

        /// <summary>
        /// Deletes a Stop.
        /// </summary>
        [HttpDelete("DeleteStop/{id}")]
        public async Task<IActionResult> DeleteStop(int id) {
            var result = await stopService.DeleteStopAsync(id);
            return result ? NoContent() : NotFound();
        }
    }

    /// <summary>
    /// DTO for creating a Stop.
    /// </summary>
    public record CreateStopRequest {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    /// <summary>
    /// DTO for updating a Stop.
    /// </summary>
    public record UpdateStopRequest {
        public string? Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}