using Backend.Core.Services.RouteRelated.RouteEdgeServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.RouteRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class RouteEdgeController : ControllerBase {
        private readonly IRouteEdgeService _routeEdgeService;

        public RouteEdgeController(IRouteEdgeService routeEdgeService) {
            _routeEdgeService = routeEdgeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteEdgeEntity>>> GetAll() {
            var gps = await _routeEdgeService.GetAllRouteEdgesAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RouteEdgeEntity>> GetById(int id) {
            var gps = await _routeEdgeService.GetRouteEdgeByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<RouteEdgeEntity>> Create([FromBody] CreateRouteEdgeDto dto) {
            var created = await _routeEdgeService.CreateRouteEdgeAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.REID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRouteEdgeDto dto) {
            var success = await _routeEdgeService.UpdateRouteEdgeAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _routeEdgeService.DeleteRouteEdgeAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}