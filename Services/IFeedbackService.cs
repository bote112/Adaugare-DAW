using DAW.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetAllFeedbackAsync();
        Task CreateFeedbackAsync(Feedback feedback);
        Task<Feedback> GetFeedbackByIdAsync(int id);
        Task UpdateFeedbackAsync(Feedback feedback);
        Task DeleteFeedbackAsync(int id);
    }
}
