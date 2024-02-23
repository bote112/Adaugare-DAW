using DAW.Data;
using DAW.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class CategoriiRepository : ICategoriiRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorii>> GetAllAsync()
        {
            return await _context.Categorii.ToListAsync();
        }

        public async Task CreateAsync(Categorii categorie)
        {
            _context.Categorii.Add(categorie);
            await _context.SaveChangesAsync();
        }

        public async Task<Categorii> GetByIdAsync(int id)
        {
            return await _context.Categorii.FindAsync(id);
        }

        public async Task UpdateAsync(Categorii categorie)
        {
            _context.Categorii.Update(categorie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categorie = await _context.Categorii.FindAsync(id);
            if (categorie != null)
            {
                _context.Categorii.Remove(categorie);
                await _context.SaveChangesAsync();
            }
        }
    }

}
