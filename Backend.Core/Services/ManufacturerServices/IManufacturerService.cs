using Backend.Data.Entities;

namespace Backend.Core.Services.ManufacturerServices {
    public interface IManufacturerService {
        /// <summary>
        /// Retrieves all manufacturers
        /// </summary>
        Task<IEnumerable<ManufacturerEntity>> GetAllManufacturersAsync();

        /// <summary>
        /// Retrieves a manufacturer by ID
        /// </summary>
        Task<ManufacturerEntity?> GetManufacturerByIdAsync(int id);

        /// <summary>
        /// Creates a new manufacturer
        /// </summary>
        Task<ManufacturerEntity> CreateManufacturerAsync(CreateManufacturerDto dto);

        /// <summary>
        /// Updates an existing manufacturer
        /// </summary>
        Task<bool> UpdateManufacturerAsync(int id, UpdateManufacturerDto dto);

        /// <summary>
        /// Deletes a manufacturer
        /// </summary>
        Task<bool> DeleteManufacturerAsync(int id);
    }
}
