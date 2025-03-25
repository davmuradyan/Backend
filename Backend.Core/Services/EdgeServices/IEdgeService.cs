using Backend.Data.Entities;

namespace Backend.Core.Services.EdgeServices {
    public interface IEdgeService {
        /// <summary>
        /// Creates a new Edge entity.
        /// </summary>
        /// <param name="startStopId">The ID of the start stop.</param>
        /// <param name="endStopId">The ID of the end stop.</param>
        /// <returns>The created Edge entity.</returns>
        Task<EdgeEntity> CreateEdgeAsync(int startStopId, int endStopId, float duration, float distance);

        /// <summary>
        /// Retrieves an Edge entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the edge.</param>
        /// <returns>The Edge entity if found, otherwise null.</returns>
        Task<EdgeEntity> GetEdgeAsync(int id);

        /// <summary>
        /// Retrieves all Edge entities.
        /// </summary>
        /// <returns>A list of all Edge entities.</returns>
        Task<List<EdgeEntity>> GetEdgesAsync();

        /// <summary>
        /// Updates an existing Edge entity.
        /// </summary>
        /// <param name="id">The ID of the edge to update.</param>
        /// <param name="startStopId">The new start stop ID (optional).</param>
        /// <param name="endStopId">The new end stop ID (optional).</param>
        /// <returns>The updated Edge entity, or null if not found.</returns>
        Task<EdgeEntity?> UpdateEdgeAsync(int id, int? startStopId, int? endStopId, float? duration, float? distance);

        /// <summary>
        /// Deletes an Edge entity by its ID.
        /// </summary>
        /// <param name="edgeId">The ID of the edge to delete.</param>
        /// <returns>True if deletion was successful, otherwise false.</returns>
        Task<bool> DeleteEdgeAsync(int edgeId);
    }
}