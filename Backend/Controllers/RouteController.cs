using Microsoft.AspNetCore.Mvc;
using Backend.Core.Services.RouteServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using Backend.Data.Entities;

namespace Backend.Controllers {
    [ApiController]
    [Route("api/routes")]
    public class RouteController : ControllerBase {
        private readonly IRouteService routeService;

        public RouteController(IRouteService routeService) {
            this.routeService = routeService;
        }

        /// <summary>
        /// Creates a new Route.
        /// </summary>
        [HttpPost("AddRoute")]
        public async Task<IActionResult> AddRoute(string name) {
            var route = await routeService.CreateRouteAsync(name);
            return Ok(route);
        }

        /// <summary>
        /// Retrieves a Route by ID.
        /// </summary>
        [HttpGet("GetRoute/{id}")]
        public async Task<IActionResult> GetRoute(int id) {
            var route = await routeService.GetRouteAsync(id);
            return route != null ? Ok(route) : NotFound();
        }

        /// <summary>
        /// Retrieves all Routes.
        /// </summary>
        [HttpGet("GetRoutes")]
        public async Task<IActionResult> GetRoutes() {
            var routes = await routeService.GetRoutesAsync();
            return Ok(routes);
        }

        /// <summary>
        /// Updates an existing Route.
        /// </summary>
        [HttpPut("UpdateRoute/{id}")]
        public async Task<IActionResult> UpdateRoute(int id, [FromBody] UpdateRouteRequest request) {
            var updatedRoute = await routeService.UpdateRouteAsync(id, request.Name);
            return updatedRoute != null ? Ok(updatedRoute) : NotFound();
        }

        /// <summary>
        /// Deletes a Route.
        /// </summary>
        [HttpDelete("DeleteRoute/{id}")]
        public async Task<IActionResult> DeleteRoute(int id) {
            var result = await routeService.DeleteRouteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }

    /// <summary>
    /// DTO for updating a route.
    /// </summary>
    public record UpdateRouteRequest {
        public string Name { get; set; }
    }
}