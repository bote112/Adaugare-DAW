using DAW.Models;
using DAW.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbackAsync()
        {
            return await _feedbackRepository.GetAllFeedbackAsync();
        }

        public async Task CreateFeedbackAsync(Feedback feedback)
        {
            await _feedbackRepository.CreateFeedbackAsync(feedback);
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int id)
        {
            return await _feedbackRepository.GetFeedbackByIdAsync(id);
        }

        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            await _feedbackRepository.UpdateFeedbackAsync(feedback);
        }

        public async Task DeleteFeedbackAsync(int id)
        {
            await _feedbackRepository.DeleteFeedbackAsync(id);
        }
    }
}
