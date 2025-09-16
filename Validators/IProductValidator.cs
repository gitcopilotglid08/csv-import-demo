using System.Collections.Generic;
using CsvImportDemo.Models;

namespace CsvImportDemo.Validators
{
    public interface IProductValidator
    {
        (bool isValid, string? error) Validate(Product product);
    }
}
