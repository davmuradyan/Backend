using Microsoft.AspNetCore.Mvc;
using Backend.Core.Services.EdgeServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using Backend.Data.Entities;

namespace Backend.Controllers {
    [ApiController]
    [Route("api/edges")]
    public class EdgeController : ControllerBase {
        private readonly IEdgeService edgeService;

        public EdgeController(IEdgeService edgeService) {
            this.edgeService = edgeService;
        }

        /// <summary>
        /// Creates a new Edge.
        /// </summary>
        [HttpPost("AddEdge")]
        public async Task<IActionResult> AddEdge(int startStopId, int endStopId, float duration, float distance) {
            var edge = await edgeService.CreateEdgeAsync(startStopId, endStopId, duration, distance);
            return Ok(edge);
        }

        /// <summary>
        /// Retrieves an Edge by ID.
        /// </summary>
        [HttpGet("GetEdge/{id}")]
        public async Task<IActionResult> GetEdge(int id) {
            var edge = await edgeService.GetEdgeAsync(id);
            return edge != null ? Ok(edge) : NotFound();
        }

        /// <summary>
        /// Retrieves all Edges.
        /// </summary>
        [HttpGet("GetEdges")]
        public async Task<IActionResult> GetEdges() {
            var edges = await edgeService.GetEdgesAsync();
            return Ok(edges);
        }

        /// <summary>
        /// Updates an existing Edge.
        /// </summary>
        [HttpPut("UpdateEdge/{id}")]
        public async Task<IActionResult> UpdateEdge(int id, [FromBody] UpdateEdgeRequest request) {
            var updatedEdge = await edgeService.UpdateEdgeAsync(id, request.StartStopId, request.EndStopId, request.Duration, request.Distance);
            return updatedEdge != null ? Ok(updatedEdge) : NotFound();
        }

        /// <summary>
        /// Deletes an Edge.
        /// </summary>
        [HttpDelete("DeleteEdge/{id}")]
        public async Task<IActionResult> DeleteEdge(int id) {
            var result = await edgeService.DeleteEdgeAsync(id);
            return result ? NoContent() : NotFound();
        }
    }

    /// <summary>
    /// DTO for updating an Edge.
    /// </summary>
    public class UpdateEdgeRequest {
        public int? StartStopId { get; set; }
        public int? EndStopId { get; set; }
        public float? Duration { get; set; }
        public float? Distance { get; set; }
    }
}