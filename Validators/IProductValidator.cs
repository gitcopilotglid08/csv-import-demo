using CsvImportDemo.Models;
using System.Collections.Generic;

namespace CsvImportDemo.Validators
{
    public interface IProductValidator
    {
        (bool isValid, string? error) Validate(Product product);
    }
}