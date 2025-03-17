using PetShopCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Services
{
    public class BaseService<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> GetByIdAsync(int id) {
            return await _repository.GetByIdAsync(id);
        } 

        public async Task<IEnumerable<T>> GetAllAsync() {

            return await _repository.GetAllAsync();
        } 

        public async Task AddAsync(T entity) {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
