using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.PersonRelated.UserServices
{
    public class UserService : IUserService
    {
        private readonly MainDBContext _context;

        public UserService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.City)
                .Include(u => u.Feedbacks)
                .ToListAsync();
        }

        public async Task<UserEntity?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.City)
                .Include(u => u.Feedbacks)
                .FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<UserEntity> CreateUserAsync(CreateUserDto dto)
        {
            var user = new UserEntity
            {
                IP = dto.IP,
                ConnectionTime = dto.ConnectionTime,
                Longitude = dto.Longitude,
                Latitude = dto.Latitude,
                DisconnectionTime = dto.DisconnectionTime,
                CityID = dto.CityID
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            if (dto.IP != null) user.IP = dto.IP;
            if (dto.ConnectionTime.HasValue) user.ConnectionTime = dto.ConnectionTime.Value;
            if (dto.Longitude.HasValue) user.Longitude = dto.Longitude.Value;
            if (dto.Latitude.HasValue) user.Latitude = dto.Latitude.Value;
            if (dto.DisconnectionTime.HasValue) user.DisconnectionTime = dto.DisconnectionTime;
            if (dto.CityID.HasValue) user.CityID = dto.CityID;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
