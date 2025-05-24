using Backend.Core.Services.RouteRelated.EdgeServices;
using Backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.RouteRelated {
    [ApiController]
    [Route("api/[controller]")]
    public class EdgeController : ControllerBase {
        private readonly IEdgeService _edgeService;

        public EdgeController(IEdgeService edgeService) {
            _edgeService = edgeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EdgeEntity>>> GetAll() {
            var gps = await _edgeService.GetAllEdgesAsync();
            return Ok(gps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EdgeEntity>> GetById(int id) {
            var gps = await _edgeService.GetEdgeByIdAsync(id);
            if (gps == null)
                return NotFound();
            return Ok(gps);
        }

        [HttpPost]
        public async Task<ActionResult<EdgeEntity>> Create([FromBody] CreateEdgeDto dto) {
            var created = await _edgeService.CreateEdgeAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.EdgeID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEdgeDto dto) {
            var success = await _edgeService.UpdateEdgeAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _edgeService.DeleteEdgeAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}