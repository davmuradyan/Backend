using Backend.Data.Entities;

namespace Backend.Core.Services.RouteEdgeServices {
    public interface IRouteEdgeService {
        /// <summary>
        /// Creates a new RouteEdge entity. 
        /// </summary>
        /// <param name="routeId">The ID of the route.</param>
        /// <param name="edgeId">The ID of the edge.</param>
        /// <param name="order">The order of the edge in the route.</param>
        /// <param name="duration">The time in minutes needed to pass the edge.</param>
        /// <param name="distance">The distance in kilometers</param>
        /// <returns>The created RouteEdge entity.</returns>
        Task<RouteEdgeEntity> CreateRouteEdgeAsync(int routeId, int edgeId, int order);

        /// <summary>
        /// Retrieves a RouteEdge entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the RouteEdge entity</param>
        /// <returns>The RouteEdge entity if found, otherwise null.</returns>
        Task<RouteEdgeEntity> GetRouteEdgeAsync(int id);

        /// <summary>
        /// Retrieves all RouteEdge entities.
        /// </summary>
        /// <returns>A list of all RouteEdge entities.</returns>
        Task<List<RouteEdgeEntity>> GetRouteEdgesAsync();

        /// <summary>
        /// Updates an existing Edge entity.
        /// </summary>
        /// <param name="id">The ID of the RouteEdge to update.</param>
        /// <param name="routeId">The new route ID (optional).</param>
        /// <param name="edgeId">The new edge ID (optional).</param>
        /// <param name="order">The new order of the edge in the route (optional).</param>
        /// <param name="duration">The new duration to pass the edge (optional).</param>
        /// <param name="distance">The new length of the edge (optional).</param>
        /// <returns>The updated RouteEdge entity, or null if not found.</returns>
        Task<RouteEdgeEntity?> UpdateRouteEdgeAsync(int id, int? routeId, int? edgeId, int? order);

        /// <summary>
        /// Deletes a RouteEdge entity by its ID.
        /// </summary>
        /// <param name="routeEdgeId">The ID of the RouteEdge to delete.</param>
        /// <returns>True if deletion was successful, otherwise false.</returns>
        Task<bool> DeleteRouteEdgeAsync(int routeEdgeId);
    }
}