using Backend.Data.Entities;

namespace Backend.Core.Services.CityServices {
    public interface ICityServices {
        /// <summary>
        /// Retrieves all cities
        /// </summary>
        Task<IEnumerable<CityEntity>> GetAllCitiesAsync();

        /// <summary>
        /// Retrieves a city by its ID
        /// </summary>
        Task<CityEntity?> GetCityByIdAsync(int id);

        /// <summary>
        /// Creates a new city
        /// </summary>
        Task<CityEntity> CreateCityAsync(CreateCityDto dto);

        /// <summary>
        /// Updates an existing city
        /// </summary>
        Task<bool> UpdateCityAsync(int id, UpdateCityDto dto);

        /// <summary>
        /// Deletes a city by its ID
        /// </summary>
        Task<bool> DeleteCityAsync(int id);
    }
}