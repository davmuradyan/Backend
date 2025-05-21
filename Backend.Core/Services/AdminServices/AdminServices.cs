using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core {
    public class AdminServices : IAdminServices {
        private readonly MainDBContext _context;

        public AdminServices(MainDBContext context) {
            _context = context;
        }

        public async Task<IEnumerable<AdminEntity>> GetAllAdminsAsync() {
            return await _context.Admins.Include(a => a.City).ToListAsync();
        }

        public async Task<AdminEntity?> GetAdminByIdAsync(int id) {
            return await _context.Admins.Include(a => a.City).FirstOrDefaultAsync(a => a.AdminID == id);
        }

        public async Task<AdminEntity> CreateAdminAsync(CreateAdminDto dto) {
            var entity = new AdminEntity {
                Name = dto.Name,
                Surname = dto.Surname,
                CityID = dto.CityID,
                Type = dto.Type,
                Username = dto.Username,
                Password = dto.Password,
                Email = dto.Email,
                Phone = dto.Phone
            };

            _context.Admins.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAdminAsync(int id, UpdateAdminDto dto) {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null) return false;

            if (dto.Name is not null) admin.Name = dto.Name;
            if (dto.Surname is not null) admin.Surname = dto.Surname;
            if (dto.CityID.HasValue) admin.CityID = dto.CityID.Value;
            if (dto.Type is not null) admin.Type = dto.Type;
            if (dto.Username is not null) admin.Username = dto.Username;
            if (dto.Password is not null) admin.Password = dto.Password;
            if (dto.Email is not null) admin.Email = dto.Email;
            if (dto.Phone is not null) admin.Phone = dto.Phone;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAdminAsync(int id) {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null) return false;

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}