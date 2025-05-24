using Backend.Core.Services.RouteRelated.RouteServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.RouteRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService) {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteEntity>>> GetAll() {
            var gps = await _routeService.GetAllRoutesAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RouteEntity>> GetById(int id) {
            var gps = await _routeService.GetRouteByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<RouteEntity>> Create([FromBody] CreateRouteDto dto) {
            var created = await _routeService.CreateRouteAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.RouteID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRouteDto dto) {
            var success = await _routeService.UpdateRouteAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _routeService.DeleteRouteAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}