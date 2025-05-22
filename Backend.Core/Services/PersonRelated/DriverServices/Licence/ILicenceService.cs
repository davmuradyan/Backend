using Backend.Data.Entities;

namespace Backend.Core.Services.PersonRelated.DriverServices.Licence
{
    public interface ILicenceService
    {
        /// <summary>
        /// Retrieves all licences
        /// </summary>
        Task<IEnumerable<LicenceEntity>> GetAllLicencesAsync();

        /// <summary>
        /// Retrieves a licence by its ID
        /// </summary>
        Task<LicenceEntity?> GetLicenceByIdAsync(int id);

        /// <summary>
        /// Creates a new licence
        /// </summary>
        Task<LicenceEntity> CreateLicenceAsync(CreateLicenceDto dto);

        /// <summary>
        /// Updates an existing licence
        /// </summary>
        Task<bool> UpdateLicenceAsync(int id, UpdateLicenceDto dto);

        /// <summary>
        /// Deletes a licence by its ID
        /// </summary>
        Task<bool> DeleteLicenceAsync(int id);
    }
}
