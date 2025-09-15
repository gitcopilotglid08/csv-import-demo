using System.Collections.Generic;
using System.Threading.Tasks;
using CsvImportDemo.Models;

namespace CsvImportDemo.Services
{
    public interface IProductService
    {
        Task<(IEnumerable<Product> validProducts, IEnumerable<string> errors)> ValidateAndParseCsvAsync(System.IO.Stream csvStream);
        Task SaveProductsAsync(IEnumerable<Product> products);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
