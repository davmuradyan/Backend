using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.PersonRelated.DriverServices.Licence
{
    public class LicenceService : ILicenceService
    {
        private readonly MainDBContext _context;

        public LicenceService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LicenceEntity>> GetAllLicencesAsync()
        {
            return await _context.Licences
                .Include(l => l.Country)
                .ToListAsync();
        }

        public async Task<LicenceEntity?> GetLicenceByIdAsync(int id)
        {
            return await _context.Licences
                .Include(l => l.Country)
                .FirstOrDefaultAsync(l => l.LicenceID == id);
        }

        public async Task<LicenceEntity> CreateLicenceAsync(CreateLicenceDto dto)
        {
            var licence = new LicenceEntity
            {
                CountryID = dto.CountryID,
                IDNum = dto.IDNum,
                Category = dto.Category
            };

            _context.Licences.Add(licence);
            await _context.SaveChangesAsync();

            return licence;
        }

        public async Task<bool> UpdateLicenceAsync(int id, UpdateLicenceDto dto)
        {
            var licence = await _context.Licences.FindAsync(id);
            if (licence == null) return false;

            if (dto.CountryID.HasValue) licence.CountryID = dto.CountryID.Value;
            if (dto.IDNum != null) licence.IDNum = dto.IDNum;
            if (dto.Category != null) licence.Category = dto.Category;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLicenceAsync(int id)
        {
            var licence = await _context.Licences.FindAsync(id);
            if (licence == null) return false;

            _context.Licences.Remove(licence);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
