using DAW.Models;
using DAW.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Services
{
    public class CategoriiService : ICategoriiService
    {
        private readonly ICategoriiRepository _categoriiRepository;

        public CategoriiService(ICategoriiRepository categoriiRepository)
        {
            _categoriiRepository = categoriiRepository;
        }

        public async Task<IEnumerable<Categorii>> GetAllCategoriiAsync()
        {
            return await _categoriiRepository.GetAllAsync();
        }

        public async Task CreateCategorieAsync(Categorii categorie)
        {
            await _categoriiRepository.CreateAsync(categorie);
        }

        public async Task<Categorii> GetCategorieByIdAsync(int id)
        {
            return await _categoriiRepository.GetByIdAsync(id);
        }

        public async Task UpdateCategorieAsync(Categorii categorie)
        {
            await _categoriiRepository.UpdateAsync(categorie);
        }

        public async Task DeleteCategorieAsync(int id)
        {
            await _categoriiRepository.DeleteAsync(id);
        }
    }
}
