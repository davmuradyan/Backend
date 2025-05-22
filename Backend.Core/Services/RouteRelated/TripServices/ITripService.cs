using Backend.Data.Entities;

namespace Backend.Core.Services.RouteRelated.TripServices
{
    public interface ITripService
    {
        Task<IEnumerable<TripEntity>> GetAllTripsAsync();
        Task<TripEntity?> GetTripByIdAsync(int id);
        Task<TripEntity> CreateTripAsync(CreateTripDto dto);
        Task<bool> UpdateTripAsync(int id, UpdateTripDto dto);
        Task<bool> DeleteTripAsync(int id);
    }
}
