using Backend.Data.Entities;

namespace Backend.Core.Services.DriverServices {
    public interface IDriverService {
        /// <summary>
        /// Create a new Driver entity.
        /// </summary>
        /// <param name="name">The name of the driver.</param>
        /// <param name="surname">The surname of the driver.</param>
        /// <param name="busId">The ID of the bus, that the driver is attached (optional).</param>
        /// <returns></returns>
        Task<DriverEntity> CreateDriverAsync(string name, string surname, int? busId);

        /// <summary>
        /// Retrieves a Driver entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the admin.</param>
        /// <returns></returns>
        Task<DriverEntity> GetDriverAsync(int id);

        /// <summary>
        /// Retrieves all Admin entities.
        /// </summary>
        /// <returns>A list of all Admin entities.</returns>
        Task<List<DriverEntity>> GetDriversAsync();

        /// <summary>
        /// Updates an existing Driver entity.
        /// </summary>
        /// <param name="id">The ID of the Driver to update.</param>
        /// <param name="name">The new name of the Driver (optional).</param>
        /// <param name="surname">The new surname of the Driver (optional).</param>
        /// <param name="busId">The new bus ID attached to the Driver (optional).</param>
        /// <returns>The updated Admin entity, or null if not found.</returns>
        Task<DriverEntity?> UpdateDriverAsync(int id, string? name, string? surname, int? busId);

        /// <summary>
        /// Deletes a Driver entity by its ID.
        /// </summary>
        /// <param name="driverId">The ID of the driver to delete.</param>
        /// <returns>True of deletion was successful, otherwise false</returns>
        Task<bool> DeleteDriverAsync(int driverId);
    }
}