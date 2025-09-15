using CsvImportDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsvImportDemo.Repositories
{
    public interface IProductRepository
    {
        Task AddProductsAsync(IEnumerable<Product> products);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}