using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Core.Services.AdminServices {
    public class AdminService : IAdminService {
        private readonly MainDBContext _context;
        private readonly ILogger<AdminService> _logger;

        public AdminService(MainDBContext context, ILogger<AdminService> logger) {
            _context = context;
            _logger = logger;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AdminEntity> CreateAdminAsync(string name, string surname, string email, string city, string username, string password) {
            try {
                var admin = new AdminEntity {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    City = city,
                    Username = username,
                    Password = password
                };

                await _context.Admins.AddAsync(admin);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Admin {AdminUsername} added successfully.", username);
                return admin;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to create admin.");
                throw;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AdminEntity> GetAdminAsync(int id) {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null) {
                throw new KeyNotFoundException($"Admin with ID {id} was not found.");
            }
            return admin;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<List<AdminEntity>> GetAdminsAsync() {
            return await _context.Admins.ToListAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AdminEntity?> UpdateAdminAsync(int id, string? name, string? surname, string? email, string? city, string? username, string? password) {
            try {
                var admin = await _context.Admins.FindAsync(id);
                if (admin == null) {
                    _logger.LogWarning("Admin with ID {AdminId} wasn't found.", id);
                    return null;
                }

                if (!string.IsNullOrEmpty(name)) admin.Name = name;
                if (!string.IsNullOrEmpty(surname)) admin.Surname = surname;
                if (!string.IsNullOrEmpty(email)) admin.Email = email;
                if (!string.IsNullOrEmpty(city)) admin.City = city;
                if (!string.IsNullOrEmpty(username)) admin.Username = username;
                if (!string.IsNullOrEmpty(password)) admin.Password = password;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Admin with ID {AdminId} updated successfully.", id);

                return admin;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to update Admin with ID {AdminId}.", id);
                return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> DeleteAdminAsync(int adminId) {
            try {
                var admin = await _context.Admins.FindAsync(adminId);
                if (admin == null) {
                    _logger.LogWarning("Admin with ID {AdminId} not found, cannot delete.", adminId);
                    return false;
                }

                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Admin with ID {AdminId} was deleted successfully.", adminId);
                return true;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to delete Admin with ID {AdminId}.", adminId);
                return false;
            }
        }
    }
}