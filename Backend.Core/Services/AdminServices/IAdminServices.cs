using Backend.Data.Entities;

namespace Backend.Core {
    public interface IAdminServices {
        /// <summary>
        /// Retrieves all admins
        /// </summary>
        public Task<IEnumerable<AdminEntity>> GetAllAdminsAsync();

        /// <summary>
        /// Retrieves an admin by its ID
        /// </summary>
        public Task<AdminEntity?> GetAdminByIdAsync(int id);

        /// <summary>
        /// Creates a new admin
        /// </summary>
        public Task<AdminEntity> CreateAdminAsync(CreateAdminDto dto);

        /// <summary>
        /// Updates an existing admin
        /// </summary>
        public Task<bool> UpdateAdminAsync(int id, UpdateAdminDto dto);

        /// <summary>
        /// Deletes an admin by its ID
        /// </summary>
        public Task<bool> DeleteAdminAsync(int id);
    }
}