using Backend.Data.Entities;

namespace Backend.Core.Services.PersonRelated.DriverServices.Driver
{
    public interface IDriverService
    {
        /// <summary>
        /// Retrieves all drivers
        /// </summary>
        Task<IEnumerable<DriverEntity>> GetAllDriversAsync();

        /// <summary>
        /// Retrieves a driver by its ID
        /// </summary>
        Task<DriverEntity?> GetDriverByIdAsync(int id);

        /// <summary>
        /// Creates a new driver
        /// </summary>
        Task<DriverEntity> CreateDriverAsync(CreateDriverDto dto);

        /// <summary>
        /// Updates an existing driver
        /// </summary>
        Task<bool> UpdateDriverAsync(int id, UpdateDriverDto dto);

        /// <summary>
        /// Deletes a driver by its ID
        /// </summary>
        Task<bool> DeleteDriverAsync(int id);
    }
}