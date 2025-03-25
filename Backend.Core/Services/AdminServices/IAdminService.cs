using Backend.Data.Entities;

namespace Backend.Core.Services.AdminServices {
    public interface IAdminService {
        /// <summary>
        /// Creates a new Admin entity.
        /// </summary>
        /// <param name="name">The name of the admin.</param>
        /// <param name="surname">The surname of the admin.</param>
        /// <param name="email">The email address of the admin.</param>
        /// <param name="city">The city of the admin.</param>
        /// <param name="username">The username of the admin's account.</param>
        /// <param name="password">The password of the admin's account.</param>
        /// <returns>The created Admin entity.</returns>
        Task<AdminEntity> CreateAdminAsync(string name, string surname, string email, string city, string username, string password);

        /// <summary>
        /// Retrieves an Admin entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the admin.</param>
        /// <returns>The Admin entity if found, otherwise null.</returns>
        Task<AdminEntity> GetAdminAsync(int id);

        /// <summary>
        /// Retrieves all Admin entities.
        /// </summary>
        /// <returns>A list of all Admin entities.</returns>
        Task<List<AdminEntity>> GetAdminsAsync();

        /// <summary>
        /// Updates an existing Admin entity.
        /// </summary>
        /// <param name="id">The ID of the Admin to update.</param>
        /// <param name="name">The new name of the Admin.</param>
        /// <param name="surname">The new surname of the Admin</param>
        /// <param name="email">The new email of the Admin.</param>
        /// <param name="city">The new city of the Admin.</param>
        /// <param name="username">The new username of the Admin.</param>
        /// <param name="password">The new password of the Admin.</param>
        /// <returns>The updated Admin entity, or null if not found.</returns>
        Task<AdminEntity?> UpdateAdminAsync(int id, string? name, string? surname, string? email, string? city, string? username, string? password);

        /// <summary>
        /// Deletes an Admin entity by its ID.
        /// </summary>
        /// <param name="adminId">The ID of the admin to delete.</param>
        /// <returns>True if deletion was successful, otherwise false.</returns>
        Task<bool> DeleteAdminAsync(int adminId);
    }
}