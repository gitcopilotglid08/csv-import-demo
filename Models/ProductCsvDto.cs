namespace CsvImportDemo.Models
{
    public class ProductCsvDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
