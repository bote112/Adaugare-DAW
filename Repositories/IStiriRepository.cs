using DAW.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public interface IStiriRepository
    {
        Task<IEnumerable<Stiri>> GetAllAsync();
        Task<Stiri> GetByIdAsync(int id);
        Task CreateAsync(Stiri stire);
        Task UpdateAsync(Stiri stire);
        Task DeleteAsync(int id);
    }
}
