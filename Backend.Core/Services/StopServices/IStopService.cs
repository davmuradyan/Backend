using Backend.Data.Entities;

namespace Backend.Core.Services.StopServices {
    public interface IStopService {
        /// <summary>
        /// Creates a new Stop entity.
        /// </summary>
        /// <param name="name">The name of the stop.</param>
        /// <param name="latitude">The latitude of the stop.</param>
        /// <param name="longitude">The longitude of the stop.</param>
        /// <returns>The created Stop entity.</returns>
        Task<StopEntity> CreateStopAsync(string name, double latitude, double longitude);

        /// <summary>
        /// Retrieves a Stop entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the stop.</param>
        /// <returns>The Stop entity if found, otherwise null.</returns>
        Task<StopEntity> GetStopAsync(int id);

        /// <summary>
        /// Retrieves all Stop entities.
        /// </summary>
        /// <returns>A list of all Stop entities.</returns>
        Task<List<StopEntity>> GetStopsAsync();

        /// <summary>
        /// Updates an existing Stop entity.
        /// </summary>
        /// <param name="id">The ID of the stop to update.</param>
        /// <param name="name">The new name of the stop.</param>
        /// <param name="latitude">The new latitude.</param>
        /// <param name="longitude">The new longitude.</param>
        /// <returns>The updated Stop entity, or null if not found.</returns>
        Task<StopEntity?> UpdateStopAsync(int id, string? name, double? latitude, double? longitude);


        /// <summary>
        /// Deletes a Stop entity by its ID.
        /// </summary>
        /// <param name="stopId">The ID of the stop to delete.</param>
        /// <returns>True if deletion was successful, otherwise false.</returns>
        Task<bool> DeleteStopAsync(int stopId);
    }
}
