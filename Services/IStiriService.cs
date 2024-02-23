using DAW.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Services
{
    public interface IStiriService
    {
        Task<IEnumerable<Stiri>> GetAllStiriAsync();
        Task<Stiri> GetStireByIdAsync(int id);
        Task CreateStireAsync(Stiri stire);
        Task UpdateStireAsync(Stiri stire);
        Task DeleteStireAsync(int id);
    }
}
