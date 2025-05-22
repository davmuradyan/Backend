using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.RouteRelated.RouteServices
{
    public class RouteService : IRouteService
    {
        private readonly MainDBContext _context;

        public RouteService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RouteEntity>> GetAllRoutesAsync()
        {
            return await _context.Routes
                .Include(r => r.RouteEdges)
                .Include(r => r.Vehicles)
                .ToListAsync();
        }

        public async Task<RouteEntity?> GetRouteByIdAsync(int id)
        {
            return await _context.Routes
                .Include(r => r.RouteEdges)
                .Include(r => r.Vehicles)
                .FirstOrDefaultAsync(r => r.RouteID == id);
        }

        public async Task<RouteEntity> CreateRouteAsync(CreateRouteDto dto)
        {
            var route = new RouteEntity
            {
                RouteNum = dto.RouteNum,
                StartHour = dto.StartHour,
                EndHour = dto.EndHour
            };

            _context.Routes.Add(route);
            await _context.SaveChangesAsync();

            return route;
        }

        public async Task<bool> UpdateRouteAsync(int id, UpdateRouteDto dto)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null) return false;

            if (dto.RouteNum.HasValue) route.RouteNum = dto.RouteNum.Value;
            if (dto.StartHour != null) route.StartHour = dto.StartHour;
            if (dto.EndHour != null) route.EndHour = dto.EndHour;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRouteAsync(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null) return false;

            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
