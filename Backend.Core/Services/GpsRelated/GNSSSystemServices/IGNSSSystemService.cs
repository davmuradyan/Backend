using Backend.Data.Entities;

namespace Backend.Core.Services.GpsRelated.GNSSSystemServices
{
    public interface IGNSSSystemService
    {
        /// <summary>
        /// Retrieves all GNSS systems
        /// </summary>
        public Task<IEnumerable<GNSSSystemEntity>> GetAllGNSSSystemsAsync();

        /// <summary>
        /// Retrieves a GNSS system by its ID
        /// </summary>
        public Task<GNSSSystemEntity?> GetGNSSSystemByIdAsync(int id);

        /// <summary>
        /// Creates a new GNSS system
        /// </summary>
        public Task<GNSSSystemEntity> CreateGNSSSystemAsync(CreateGNSSSystemDto dto);

        /// <summary>
        /// Updates an existing GNSS system
        /// </summary>
        public Task<bool> UpdateGNSSSystemAsync(int id, UpdateGNSSSystemDto dto);

        /// <summary>
        /// Deletes a GNSS system by its ID
        /// </summary>
        public Task<bool> DeleteGNSSSystemAsync(int id);
    }
}