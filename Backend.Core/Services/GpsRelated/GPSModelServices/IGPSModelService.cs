using Backend.Data.Entities;

namespace Backend.Core.Services.GpsRelated.GPSModelServices
{
    public interface IGPSModelService
    {
        /// <summary>
        /// Retrieves all GPS models
        /// </summary>
        Task<IEnumerable<GPSModelEntity>> GetAllGPSModelsAsync();

        /// <summary>
        /// Retrieves a GPS model by its ID
        /// </summary>
        Task<GPSModelEntity?> GetGPSModelByIdAsync(int id);

        /// <summary>
        /// Creates a new GPS model
        /// </summary>
        Task<GPSModelEntity> CreateGPSModelAsync(CreateGPSModelDto dto);

        /// <summary>
        /// Updates an existing GPS model
        /// </summary>
        Task<bool> UpdateGPSModelAsync(int id, UpdateGPSModelDto dto);

        /// <summary>
        /// Deletes a GPS model by its ID
        /// </summary>
        Task<bool> DeleteGPSModelAsync(int id);
    }
}
