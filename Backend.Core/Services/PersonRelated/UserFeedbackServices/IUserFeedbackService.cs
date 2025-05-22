using Backend.Data.Entities;

namespace Backend.Core.Services.PersonRelated.UserFeedbackServices
{
    public interface IUserFeedbackService
    {
        Task<IEnumerable<UserFeedbackEntity>> GetAllFeedbacksAsync();
        Task<UserFeedbackEntity?> GetFeedbackByIdAsync(int id);
        Task<UserFeedbackEntity> CreateFeedbackAsync(CreateUserFeedbackDto dto);
        Task<bool> UpdateFeedbackAsync(int id, UpdateUserFeedbackDto dto);
        Task<bool> DeleteFeedbackAsync(int id);
    }
}
