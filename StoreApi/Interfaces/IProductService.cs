using StoreApi.Models;

namespace StoreApi.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync (Product product);
        Task DeleteAsync(int id);
    }
}
