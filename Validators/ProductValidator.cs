using CsvImportDemo.Models;
using System.Text.RegularExpressions;

namespace CsvImportDemo.Validators
{
    public class ProductValidator : IProductValidator
    {
        public (bool isValid, string? error) Validate(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                return (false, "Product name is required.");
            if (product.Price < 0)
                return (false, "Product price cannot be negative.");
            if (product.Quantity < 0)
                return (false, "Product quantity cannot be negative.");
            return (true, null);
        }
    }
}