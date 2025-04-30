using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync() =>
            await _context.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id) =>
            await _context.Products.FindAsync(id);

        public async Task AddAsync (Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync (Product product)
        {
             _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync (int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null) return;
             _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
