using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository) 
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Product> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task AddAsync(Product product) => 
            await _repository.AddAsync(product);

        public async Task UpdateAsync(Product product) =>
            await _repository.UpdateAsync(product);

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
