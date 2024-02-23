using DAW.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public interface ICategoriiRepository
    {
        Task<IEnumerable<Categorii>> GetAllAsync();
        Task CreateAsync(Categorii categorie);
        Task<Categorii> GetByIdAsync(int id);
        Task UpdateAsync(Categorii categorie);
        Task DeleteAsync(int id);
    }
}
