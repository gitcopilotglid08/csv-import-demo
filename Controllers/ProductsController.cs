using CsvImportDemo.Models;
using CsvImportDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace CsvImportDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpPost("import-csv")]
        public async Task<IActionResult> ImportCsv([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "No file uploaded." });

            if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                return BadRequest(new { message = "Please upload a CSV file." });

            try
            {
                using (var stream = file.OpenReadStream())
                {
                    var (validProducts, errors) = await _service.ValidateAndParseCsvAsync(stream);
                    
                    if (errors != null && errors.Any())
                        return BadRequest(new { message = "Validation errors found", errors });
                    
                    if (!validProducts.Any())
                        return BadRequest(new { message = "No valid products found in the CSV file." });
                    
                    await _service.SaveProductsAsync(validProducts);
                    return Ok(new { message = "Products imported successfully.", count = validProducts.Count() });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error processing file", error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products);
        }
    }
}