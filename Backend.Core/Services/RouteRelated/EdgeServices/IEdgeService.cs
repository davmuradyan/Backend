using Backend.Data.Entities;

namespace Backend.Core.Services.RouteRelated.EdgeServices
{
    public interface IEdgeService
    {
        /// <summary>
        /// Retrieves all edges
        /// </summary>
        Task<IEnumerable<EdgeEntity>> GetAllEdgesAsync();

        /// <summary>
        /// Retrieves an edge by its ID
        /// </summary>
        Task<EdgeEntity?> GetEdgeByIdAsync(int id);

        /// <summary>
        /// Creates a new edge
        /// </summary>
        Task<EdgeEntity> CreateEdgeAsync(CreateEdgeDto dto);

        /// <summary>
        /// Updates an existing edge
        /// </summary>
        Task<bool> UpdateEdgeAsync(int id, UpdateEdgeDto dto);

        /// <summary>
        /// Deletes an edge by its ID
        /// </summary>
        Task<bool> DeleteEdgeAsync(int id);
    }
}
