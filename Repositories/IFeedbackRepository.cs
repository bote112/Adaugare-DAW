using DAW.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public interface IFeedbackRepository
    {
        Task<List<Feedback>> GetAllFeedbackAsync(); // Numele metodei aici trebuie să fie exact cum doriți să o apelați
        Task CreateFeedbackAsync(Feedback feedback);
        Task<Feedback> GetFeedbackByIdAsync(int id);
        Task UpdateFeedbackAsync(Feedback feedback);
        Task DeleteFeedbackAsync(int id);
    }

}
