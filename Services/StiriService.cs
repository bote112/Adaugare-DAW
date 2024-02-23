using DAW.Models;
using DAW.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Services
{
    public class StiriService : IStiriService
    {
        private readonly IStiriRepository _stiriRepository;

        public StiriService(IStiriRepository stiriRepository)
        {
            _stiriRepository = stiriRepository;
        }

        public async Task<IEnumerable<Stiri>> GetAllStiriAsync()
        {
            return await _stiriRepository.GetAllAsync();
        }

        public async Task<Stiri> GetStireByIdAsync(int id)
        {
            return await _stiriRepository.GetByIdAsync(id);
        }

        public async Task CreateStireAsync(Stiri stire)
        {
            await _stiriRepository.CreateAsync(stire);
        }

        public async Task UpdateStireAsync(Stiri stire)
        {
            await _stiriRepository.UpdateAsync(stire);
        }

        public async Task DeleteStireAsync(int id)
        {
            await _stiriRepository.DeleteAsync(id);
        }
    }
}
