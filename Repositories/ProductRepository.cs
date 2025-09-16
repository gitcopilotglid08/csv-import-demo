using System.Collections.Generic;
using System.Threading.Tasks;
using CsvImportDemo.Data;
using CsvImportDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CsvImportDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProductsAsync(IEnumerable<Product> products)
        {
            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
