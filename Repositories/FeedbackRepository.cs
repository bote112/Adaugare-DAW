using DAW.Data;
using DAW.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Feedback>> GetAllFeedbackAsync() // Asigurați-vă că numele metodei aici corespunde cu interfața
        {
            return await _context.Feedback.ToListAsync();
        }

        public async Task CreateFeedbackAsync(Feedback feedback)
        {
            _context.Feedback.Add(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int id)
        {
            return await _context.Feedback.FindAsync(id);
        }

        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            _context.Feedback.Update(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFeedbackAsync(int id)
        {
            var feedback = await _context.Feedback.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedback.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }
    }
}
