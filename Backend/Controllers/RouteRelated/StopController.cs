using Backend.Core.Services.RouteRelated.StopServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.RouteRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class StopController : ControllerBase {
        private readonly IStopService _routeEdgeService;

        public StopController(IStopService routeEdgeService) {
            _routeEdgeService = routeEdgeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StopEntity>>> GetAll() {
            var gps = await _routeEdgeService.GetAllStopsAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StopEntity>> GetById(int id) {
            var gps = await _routeEdgeService.GetStopByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<StopEntity>> Create([FromBody] CreateStopDto dto) {
            var created = await _routeEdgeService.CreateStopAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.StopID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStopDto dto) {
            var success = await _routeEdgeService.UpdateStopAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _routeEdgeService.DeleteStopAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}