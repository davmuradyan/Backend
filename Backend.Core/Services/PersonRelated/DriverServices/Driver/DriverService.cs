using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.PersonRelated.DriverServices.Driver
{
    public class DriverService : IDriverService
    {
        private readonly MainDBContext _context;

        public DriverService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DriverEntity>> GetAllDriversAsync()
        {
            return await _context.Drivers.Include(d => d.Licence).ToListAsync();
        }

        public async Task<DriverEntity?> GetDriverByIdAsync(int id)
        {
            return await _context.Drivers.Include(d => d.Licence)
                                         .FirstOrDefaultAsync(d => d.DriverID == id);
        }

        public async Task<DriverEntity> CreateDriverAsync(CreateDriverDto dto)
        {
            var driver = new DriverEntity
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Birthdate = dto.Birthdate,
                LicenceID = dto.LicenceID
            };

            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return driver;
        }

        public async Task<bool> UpdateDriverAsync(int id, UpdateDriverDto dto)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null) return false;

            if (dto.Name != null) driver.Name = dto.Name;
            if (dto.Surname != null) driver.Surname = dto.Surname;
            if (dto.Birthdate.HasValue) driver.Birthdate = dto.Birthdate.Value;
            if (dto.LicenceID.HasValue) driver.LicenceID = dto.LicenceID.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDriverAsync(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null) return false;

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}