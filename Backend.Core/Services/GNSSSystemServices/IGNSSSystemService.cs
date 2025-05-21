using Backend.Data.Entities;

namespace Backend.Core.Services.GNSSSystemServices {
    public interface IGNSSSystemService {
        /// <summary>
        /// Retrieves all GNSS systems
        /// </summary>
        Task<IEnumerable<GNSSSystemEntity>> GetAllGNSSSystemsAsync();

        /// <summary>
        /// Retrieves a GNSS system by its ID
        /// </summary>
        Task<GNSSSystemEntity?> GetGNSSSystemByIdAsync(int id);

        /// <summary>
        /// Creates a new GNSS system
        /// </summary>
        Task<GNSSSystemEntity> CreateGNSSSystemAsync(CreateGNSSSystemDto dto);

        /// <summary>
        /// Updates an existing GNSS system
        /// </summary>
        Task<bool> UpdateGNSSSystemAsync(int id, UpdateGNSSSystemDto dto);

        /// <summary>
        /// Deletes a GNSS system by its ID
        /// </summary>
        Task<bool> DeleteGNSSSystemAsync(int id);
    }
}