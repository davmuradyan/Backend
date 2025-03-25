using Backend.Data.Entities;

namespace Backend.Core.Services.BusServices {
    public interface IBusService {
        /// <summary>
        /// Creates a new Bus entity.
        /// </summary>
        /// <param name="model">The model of the bus.</param>
        /// <param name="capacityStanding">The standing capacity of the bus.</param>
        /// <param name="capacitySitting">The sitting capacity of the bus.</param>
        /// <param name="routeId">The ID of the route assigned to the bus (optional).</param>
        /// <param name="licensePlate">The license plate of the bus.</param>
        /// <returns>The created Bus entity.</returns>
        Task<BusEntity> CreateBusAsync(string model, int capacityStanding, int capacitySitting, int? routeId, string licensePlate);

        /// <summary>
        /// Retrieves a Bus entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the bus.</param>
        /// <returns>The Bus entity if found, otherwise null.</returns>
        Task<BusEntity> GetBusAsync(int id);

        /// <summary>
        /// Retrieves all Bus entities.
        /// </summary>
        /// <returns>A list of all Bus entities.</returns>
        Task<List<BusEntity>> GetBusesAsync();

        /// <summary>
        /// Updates an existing Bus entity.
        /// </summary>
        /// <param name="id">The ID of the bus to update.</param>
        /// <param name="model">The new model of the bus (optional).</param>
        /// <param name="capacityStanding">The new standing capacity of the bus (optional).</param>
        /// <param name="capacitySitting">The new sitting capacity of the bus (optional).</param>
        /// <param name="routeId">The new route ID assigned to the bus (optional).</param>
        /// <param name="licensePlate">The new license plate of the bus (optional).</param>
        /// <returns>The updated Bus entity, or null if not found.</returns>
        Task<BusEntity?> UpdateBusAsync(int id, string? model, int? capacityStanding, int? capacitySitting, int? routeId, string? licensePlate);

        /// <summary>
        /// Deletes a Bus entity by its ID.
        /// </summary>
        /// <param name="busId">The ID of the bus to delete.</param>
        /// <returns>True if deletion was successful, otherwise false.</returns>
        Task<bool> DeleteBusAsync(int busId);
    }
}