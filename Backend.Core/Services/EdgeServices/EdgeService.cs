using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.EdgeServices {
    public class EdgeService : IEdgeService {
        private readonly MainDBContext _context;

        public EdgeService(MainDBContext context) {
            _context = context;
        }

        public async Task<IEnumerable<EdgeEntity>> GetAllEdgesAsync() {
            return await _context.Edges
                .Include(e => e.StopARef)
                .Include(e => e.StopBRef)
                .ToListAsync();
        }

        public async Task<EdgeEntity?> GetEdgeByIdAsync(int id) {
            return await _context.Edges
                .Include(e => e.StopARef)
                .Include(e => e.StopBRef)
                .FirstOrDefaultAsync(e => e.EdgeID == id);
        }

        public async Task<EdgeEntity> CreateEdgeAsync(CreateEdgeDto dto) {
            var edge = new EdgeEntity {
                StopA = dto.StopA,
                StopB = dto.StopB,
                Distance = dto.Distance,
                ExpectedTime = dto.ExpectedTime,
                ExpectedSpeed = dto.ExpectedSpeed
            };

            _context.Edges.Add(edge);
            await _context.SaveChangesAsync();

            return edge;
        }

        public async Task<bool> UpdateEdgeAsync(int id, UpdateEdgeDto dto) {
            var edge = await _context.Edges.FindAsync(id);
            if (edge == null) return false;

            if (dto.StopA.HasValue) edge.StopA = dto.StopA.Value;
            if (dto.StopB.HasValue) edge.StopB = dto.StopB.Value;
            if (dto.Distance.HasValue) edge.Distance = dto.Distance.Value;
            if (dto.ExpectedTime.HasValue) edge.ExpectedTime = dto.ExpectedTime.Value;
            if (dto.ExpectedSpeed.HasValue) edge.ExpectedSpeed = dto.ExpectedSpeed.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEdgeAsync(int id) {
            var edge = await _context.Edges.FindAsync(id);
            if (edge == null) return false;

            _context.Edges.Remove(edge);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
