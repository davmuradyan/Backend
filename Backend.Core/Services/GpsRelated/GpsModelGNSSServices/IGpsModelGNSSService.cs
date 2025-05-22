using Backend.Data.Entities;

namespace Backend.Core.Services.GpsRelated.GpsModelGNSSServices
{
    public interface IGpsModelGNSSService
    {
        /// <summary>
        /// Gets all GPS model <-> GNSS system links
        /// </summary>
        Task<IEnumerable<GpsModelGNSSEntity>> GetAllLinksAsync();

        /// <summary>
        /// Gets a specific link by ID
        /// </summary>
        Task<GpsModelGNSSEntity?> GetLinkByIdAsync(int id);

        /// <summary>
        /// Creates a new GPS model <-> GNSS system link
        /// </summary>
        Task<GpsModelGNSSEntity> CreateLinkAsync(CreateGpsModelGNSSDto dto);

        /// <summary>
        /// Deletes a GPS model <-> GNSS system link by ID
        /// </summary>
        Task<bool> DeleteLinkAsync(int id);
    }
}
