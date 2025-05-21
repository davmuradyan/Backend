using Backend.Data.Entities;

namespace Backend.Core.Services.GPSServices {
    public interface IGPSService {
        /// <summary>
        /// Retrieves all GPS devices
        /// </summary>
        Task<IEnumerable<GPSEntity>> GetAllGPSAsync();

        /// <summary>
        /// Retrieves a GPS device by its internal ID
        /// </summary>
        Task<GPSEntity?> GetGPSByIdAsync(int id);

        /// <summary>
        /// Creates a new GPS device
        /// </summary>
        Task<GPSEntity> CreateGPSAsync(CreateGPSDto dto);

        /// <summary>
        /// Updates an existing GPS device
        /// </summary>
        Task<bool> UpdateGPSAsync(int id, UpdateGPSDto dto);

        /// <summary>
        /// Deletes a GPS device by its internal ID
        /// </summary>
        Task<bool> DeleteGPSAsync(int id);
    }
}
