using Backend.Data.Entities;

namespace Backend.Core.Services.RouteServices {
    public interface IRouteService {
        /// <summary>
        /// Creates a new Route entity.
        /// </summary>
        /// <param name="name">The name of the route.</param>
        /// <returns>The created Route entity.</returns>
        Task<RouteEntity> CreateRouteAsync(string name);

        /// <summary>
        /// Retrieves a Route entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the route.</param>
        /// <returns>The Edge entity if found, otherwise null.</returns>
        Task<RouteEntity> GetRouteAsync(int id);

        /// <summary>
        /// Retrieves all Route entities.
        /// </summary>
        /// <returns>A list of all Route entities.</returns>
        Task<List<RouteEntity>> GetRoutesAsync();

        /// <summary>
        /// Updates an existing Route entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<RouteEntity?> UpdateRouteAsync(int id, string name);

        /// <summary>
        /// Deletes a Route entity by its ID.
        /// </summary>
        /// <param name="routeId">The ID of the route to delete.</param>
        /// <returns>True if deletion was successful, otherwise false.</returns>
        Task<bool> DeleteRouteAsync(int routeId);
    }
}