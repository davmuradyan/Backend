using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Core.Services.DriverServices {
    public class DriverService : IDriverService {
        private readonly MainDBContext _context;
        private readonly ILogger<DriverService> _logger;

        public DriverService(MainDBContext context, ILogger<DriverService> logger) {
            _context = context;
            _logger = logger;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<DriverEntity> CreateDriverAsync(string name, string surname, int? busId) {
            try {
                var driver = new DriverEntity {
                    Name = name,
                    Surname = surname,
                    Bus_id = busId
                };

                await _context.Drivers.AddAsync(driver);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Driver {DriverName} {DriverSurname} added successfully.", name, surname);
                return driver;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to create driver.");
                throw;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<DriverEntity> GetDriverAsync(int id) {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null) {
                throw new KeyNotFoundException($"Driver with ID {id} was not found.");
            }
            return driver;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<List<DriverEntity>> GetDriversAsync() {
            return await _context.Drivers.ToListAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<DriverEntity?> UpdateDriverAsync(int id, string? name, string? surname, int? busId) {
            try {
                var driver = await _context.Drivers.FindAsync(id);
                if (driver == null) {
                    _logger.LogWarning("Driver with ID {DriverId} wasn't found.", id);
                    return null;
                }

                if (!string.IsNullOrEmpty(name)) driver.Name = name;
                if (!string.IsNullOrEmpty(surname)) driver.Surname = surname;
                driver.Bus_id = busId;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Driver with ID {DriverId} updated successfully.", id);

                return driver;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to update Driver with ID {DriverId}.", id);
                return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> DeleteDriverAsync(int driverId) {
            try {
                var driver = await _context.Drivers.FindAsync(driverId);
                if (driver == null) {
                    _logger.LogWarning("Driver with ID {DriverId} not found, cannot delete.", driverId);
                    return false;
                }

                _context.Drivers.Remove(driver);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Driver with ID {DriverId} was deleted successfully.", driverId);
                return true;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to delete Driver with ID {DriverId}.", driverId);
                return false;
            }
        }
    }
}