using DAW.Data;
using DAW.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class StiriRepository : IStiriRepository
    {
        private readonly ApplicationDbContext _context;

        public StiriRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stiri>> GetAllAsync()
        {
            return await _context.Stiri.ToListAsync();
        }

        public async Task<Stiri> GetByIdAsync(int id)
        {
            return await _context.Stiri.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateAsync(Stiri stire)
        {
            _context.Stiri.Add(stire);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stiri stire)
        {
            _context.Entry(stire).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stire = await _context.Stiri.FindAsync(id);
            if (stire != null)
            {
                _context.Stiri.Remove(stire);
                await _context.SaveChangesAsync();
            }
        }
    }
}
