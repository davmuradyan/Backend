using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.LocationRelated.CountryServices
{
    public class CountryService : ICountryService
    {
        private readonly MainDBContext _context;

        public CountryService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CountryEntity>> GetAllCountriesAsync()
        {
            return await _context.Countries
                .Include(c => c.Regions)
                .Include(c => c.Manufacturers)
                .Include(c => c.GNSSSystems)
                .Include(c => c.Licences)
                .ToListAsync();
        }

        public async Task<CountryEntity?> GetCountryByIdAsync(int id)
        {
            return await _context.Countries
                .Include(c => c.Regions)
                .Include(c => c.Manufacturers)
                .Include(c => c.GNSSSystems)
                .Include(c => c.Licences)
                .FirstOrDefaultAsync(c => c.CountryID == id);
        }

        public async Task<CountryEntity> CreateCountryAsync(CreateCountryDto dto)
        {
            var country = new CountryEntity
            {
                Name = dto.Name,
                Population = dto.Population,
                LastUpdateDate = DateTime.UtcNow
            };

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<bool> UpdateCountryAsync(int id, UpdateCountryDto dto)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null) return false;

            if (dto.Name != null) country.Name = dto.Name;
            if (dto.Population.HasValue) country.Population = dto.Population.Value;

            country.LastUpdateDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null) return false;

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
