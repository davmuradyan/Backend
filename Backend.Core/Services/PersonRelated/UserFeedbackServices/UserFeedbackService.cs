using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.PersonRelated.UserFeedbackServices
{
    public class UserFeedbackService : IUserFeedbackService
    {
        private readonly MainDBContext _context;

        public UserFeedbackService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserFeedbackEntity>> GetAllFeedbacksAsync()
        {
            return await _context.UserFeedbacks
                .Include(f => f.User)
                .ToListAsync();
        }

        public async Task<UserFeedbackEntity?> GetFeedbackByIdAsync(int id)
        {
            return await _context.UserFeedbacks
                .Include(f => f.User)
                .FirstOrDefaultAsync(f => f.UserFeedbackID == id);
        }

        public async Task<UserFeedbackEntity> CreateFeedbackAsync(CreateUserFeedbackDto dto)
        {
            var feedback = new UserFeedbackEntity
            {
                UserID = dto.UserID,
                Email = dto.Email,
                Message = dto.Message,
                Rating = dto.Rating,
                SubmitDate = dto.SubmitDate
            };

            _context.UserFeedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<bool> UpdateFeedbackAsync(int id, UpdateUserFeedbackDto dto)
        {
            var feedback = await _context.UserFeedbacks.FindAsync(id);
            if (feedback == null) return false;

            if (dto.Email != null) feedback.Email = dto.Email;
            if (dto.Message != null) feedback.Message = dto.Message;
            if (dto.Rating.HasValue) feedback.Rating = dto.Rating;
            if (dto.SubmitDate.HasValue) feedback.SubmitDate = dto.SubmitDate.Value;
            if (dto.UserID.HasValue) feedback.UserID = dto.UserID.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFeedbackAsync(int id)
        {
            var feedback = await _context.UserFeedbacks.FindAsync(id);
            if (feedback == null) return false;

            _context.UserFeedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
