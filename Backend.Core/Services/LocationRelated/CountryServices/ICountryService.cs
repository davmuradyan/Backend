using Backend.Data.Entities;

namespace Backend.Core.Services.LocationRelated.CountryServices
{
    public interface ICountryService
    {
        /// <summary>
        /// Retrieves all countries
        /// </summary>
        Task<IEnumerable<CountryEntity>> GetAllCountriesAsync();

        /// <summary>
        /// Retrieves a country by its ID
        /// </summary>
        Task<CountryEntity?> GetCountryByIdAsync(int id);

        /// <summary>
        /// Creates a new country
        /// </summary>
        Task<CountryEntity> CreateCountryAsync(CreateCountryDto dto);

        /// <summary>
        /// Updates an existing country
        /// </summary>
        Task<bool> UpdateCountryAsync(int id, UpdateCountryDto dto);

        /// <summary>
        /// Deletes a country by its ID
        /// </summary>
        Task<bool> DeleteCountryAsync(int id);
    }
}