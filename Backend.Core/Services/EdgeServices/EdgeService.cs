using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Core.Services.EdgeServices {
    public class EdgeService : IEdgeService {
        private readonly MainDBContext _context;
        private readonly ILogger<EdgeService> _logger;

        public EdgeService(MainDBContext context, ILogger<EdgeService> logger) {
            _context = context;
            _logger = logger;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<EdgeEntity> CreateEdgeAsync(int startStopId, int endStopId, float duration, float distance) {
            try {
                if (startStopId == endStopId) {
                    throw new ArgumentException("Start and End stops cannot be the same.");
                }

                if (duration < 0 || distance < 0) {
                    throw new ArgumentException("The distance and duration are necessarily positive floats.");
                }

                var edge = new EdgeEntity {
                    Start_stop_id = startStopId,
                    End_stop_id = endStopId,
                    Duration = duration,
                    Distance = distance
                };

                await _context.Edges.AddAsync(edge);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Edge from Stop {StartStopId} to Stop {EndStopId} added successfully.", startStopId, endStopId);
                return edge;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to create the edge");
                throw;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<EdgeEntity> GetEdgeAsync(int id) {
            var edge = await _context.Edges.FindAsync(id);
            if (edge == null) {
                throw new KeyNotFoundException($"Edge with ID {id} was not found.");
            }
            return edge;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<List<EdgeEntity>> GetEdgesAsync() {
            return await _context.Edges.ToListAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<EdgeEntity?> UpdateEdgeAsync(int id, int? startStopId, int? endStopId, float? duration, float? distance) {
            try {
                var edge = await _context.Edges.FindAsync(id);
                if (edge == null) {
                    _logger.LogWarning("Edge with ID {EdgeId} wasn't found.", id);
                    return null;
                }

                if (startStopId.HasValue) edge.Start_stop_id = startStopId.Value;
                
                if (endStopId.HasValue) edge.End_stop_id = endStopId.Value;

                if (duration.HasValue) edge.Duration = duration.Value;
                
                if (distance.HasValue) edge.Distance = distance.Value;
                

                await _context.SaveChangesAsync();
                _logger.LogInformation("Edge with ID {EdgeId} updated successfully.", id);

                return edge;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to update Edge with ID {EdgeId}.", id);
                return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> DeleteEdgeAsync(int edgeId) {
            try {
                var edge = await _context.Edges.FindAsync(edgeId);
                if (edge == null) {
                    _logger.LogWarning("Edge with ID {EdgeId} not found, cannot delete.", edgeId);
                    return false;
                }

                _context.Edges.Remove(edge);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Edge with ID {EdgeId} was deleted successfully.", edgeId);
                return true;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to delete Edge with ID {EdgeId}.", edgeId);
                return false;
            }
        }
    }
}