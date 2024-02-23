using DAW.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Services
{
    public interface ICategoriiService
    {
        Task<IEnumerable<Categorii>> GetAllCategoriiAsync();
        Task CreateCategorieAsync(Categorii categorie);
        Task<Categorii> GetCategorieByIdAsync(int id);
        Task UpdateCategorieAsync(Categorii categorie);
        Task DeleteCategorieAsync(int id);
    }
}
