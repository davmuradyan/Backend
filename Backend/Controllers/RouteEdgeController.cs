using Microsoft.AspNetCore.Mvc;
using Backend.Core.Services.RouteEdgeServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using Backend.Data.Entities;

namespace Backend.Controllers {
    [ApiController]
    [Route("api/route-edges")]
    public class RouteEdgeController : ControllerBase {
        private readonly IRouteEdgeService routeEdgeService;

        public RouteEdgeController(IRouteEdgeService routeEdgeService) {
            this.routeEdgeService = routeEdgeService;
        }

        /// <summary>
        /// Creates a new RouteEdge.
        /// </summary>
        [HttpPost("AddRouteEdge")]
        public async Task<IActionResult> AddRouteEdge(int routeId, int edgeId, int order) {
            var routeEdge = await routeEdgeService.CreateRouteEdgeAsync(routeId, edgeId, order);
            return Ok(routeEdge);
        }

        /// <summary>
        /// Retrieves a RouteEdge by ID.
        /// </summary>
        [HttpGet("GetRouteEdge/{id}")]
        public async Task<IActionResult> GetRouteEdge(int id) {
            var routeEdge = await routeEdgeService.GetRouteEdgeAsync(id);
            return routeEdge != null ? Ok(routeEdge) : NotFound();
        }

        /// <summary>
        /// Retrieves all RouteEdges.
        /// </summary>
        [HttpGet("GetRouteEdges")]
        public async Task<IActionResult> GetRouteEdges() {
            var routeEdges = await routeEdgeService.GetRouteEdgesAsync();
            return Ok(routeEdges);
        }

        /// <summary>
        /// Updates an existing RouteEdge.
        /// </summary>
        [HttpPut("UpdateRouteEdge/{id}")]
        public async Task<IActionResult> UpdateRouteEdge(int id, [FromBody] UpdateRouteEdgeRequest request) {
            var updatedRouteEdge = await routeEdgeService.UpdateRouteEdgeAsync(id, request.RouteId, request.EdgeId, request.Order);
            return updatedRouteEdge != null ? Ok(updatedRouteEdge) : NotFound();
        }

        /// <summary>
        /// Deletes a RouteEdge.
        /// </summary>
        [HttpDelete("DeleteRouteEdge/{id}")]
        public async Task<IActionResult> DeleteRouteEdge(int id) {
            var result = await routeEdgeService.DeleteRouteEdgeAsync(id);
            return result ? NoContent() : NotFound();
        }
    }

    /// <summary>
    /// DTO for updating a RouteEdge.
    /// </summary>
    public record UpdateRouteEdgeRequest {
        public int? RouteId { get; set; }
        public int? EdgeId { get; set; }
        public int? Order { get; set; }
    }
}
