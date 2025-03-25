using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Core.Services.BusServices {
    public class BusService : IBusService {
        private readonly MainDBContext _context;
        private readonly ILogger<BusService> _logger;

        public BusService(MainDBContext context, ILogger<BusService> logger) {
            _context = context;
            _logger = logger;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<BusEntity> CreateBusAsync(string model, int capacityStanding, int capacitySitting, int? routeId, string licensePlate) {
            try {
                var bus = new BusEntity {
                    Model = model,
                    Capasity_standing = capacityStanding,
                    Capasity_sitting = capacitySitting,
                    Route_id = routeId,
                    Bus_license_plate = licensePlate
                };

                await _context.Buses.AddAsync(bus);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Bus {BusModel} added successfully.", model);
                return bus;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to create bus.");
                throw;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<BusEntity> GetBusAsync(int id) {
            var bus = await _context.Buses.FindAsync(id);
            if (bus == null) {
                throw new KeyNotFoundException($"Bus with ID {id} was not found.");
            }
            return bus;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<List<BusEntity>> GetBusesAsync() {
            return await _context.Buses.ToListAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<BusEntity?> UpdateBusAsync(int id, string? model, int? capacityStanding, int? capacitySitting, int? routeId, string? licensePlate) {
            try {
                var bus = await _context.Buses.FindAsync(id);
                if (bus == null) {
                    _logger.LogWarning("Bus with ID {BusId} wasn't found.", id);
                    return null;
                }

                if (!string.IsNullOrEmpty(model)) bus.Model = model;
                if (capacityStanding.HasValue) bus.Capasity_standing = capacityStanding.Value;
                if (capacitySitting.HasValue) bus.Capasity_sitting = capacitySitting.Value;
                if (routeId.HasValue) bus.Route_id = routeId;
                if (!string.IsNullOrEmpty(licensePlate)) bus.Bus_license_plate = licensePlate;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Bus with ID {BusId} updated successfully.", id);

                return bus;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to update Bus with ID {BusId}.", id);
                return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> DeleteBusAsync(int busId) {
            try {
                var bus = await _context.Buses.FindAsync(busId);
                if (bus == null) {
                    _logger.LogWarning("Bus with ID {BusId} not found, cannot delete.", busId);
                    return false;
                }

                _context.Buses.Remove(bus);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Bus with ID {BusId} was deleted successfully.", busId);
                return true;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to delete Bus with ID {BusId}.", busId);
                return false;
            }
        }
    }
}