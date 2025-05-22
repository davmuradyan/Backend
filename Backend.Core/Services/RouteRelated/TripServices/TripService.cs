using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.RouteRelated.TripServices
{
    public class TripService : ITripService
    {
        private readonly MainDBContext _context;

        public TripService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TripEntity>> GetAllTripsAsync()
        {
            return await _context.Trips
                .Include(t => t.Vehicle)
                .Include(t => t.StartStop)
                .Include(t => t.EndStop)
                .ToListAsync();
        }

        public async Task<TripEntity?> GetTripByIdAsync(int id)
        {
            return await _context.Trips
                .Include(t => t.Vehicle)
                .Include(t => t.StartStop)
                .Include(t => t.EndStop)
                .FirstOrDefaultAsync(t => t.TripID == id);
        }

        public async Task<TripEntity> CreateTripAsync(CreateTripDto dto)
        {
            var trip = new TripEntity
            {
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                VehicleID = dto.VehicleID,
                StartStopID = dto.StartStopID,
                EndStopID = dto.EndStopID,
                EndStopWaitSecs = dto.EndStopWaitSecs
            };

            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
            return trip;
        }

        public async Task<bool> UpdateTripAsync(int id, UpdateTripDto dto)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null) return false;

            if (dto.StartTime.HasValue) trip.StartTime = dto.StartTime.Value;
            if (dto.EndTime.HasValue) trip.EndTime = dto.EndTime;
            if (dto.VehicleID.HasValue) trip.VehicleID = dto.VehicleID.Value;
            if (dto.StartStopID.HasValue) trip.StartStopID = dto.StartStopID.Value;
            if (dto.EndStopID.HasValue) trip.EndStopID = dto.EndStopID.Value;
            if (dto.EndStopWaitSecs.HasValue) trip.EndStopWaitSecs = dto.EndStopWaitSecs.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTripAsync(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null) return false;

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
