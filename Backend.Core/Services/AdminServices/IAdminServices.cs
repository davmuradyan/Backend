using Backend.Data.Entities;

namespace Backend.Core {
    public interface IAdminServices {
        public Task<IEnumerable<AdminEntity>> GetAllAdminsAsync();
        public Task<AdminEntity?> GetAdminByIdAsync(int id);
        public Task<AdminEntity> CreateAdminAsync(CreateAdminDto dto);
        public Task<bool> UpdateAdminAsync(int id, UpdateAdminDto dto);
        public Task<bool> DeleteAdminAsync(int id);
    }
}