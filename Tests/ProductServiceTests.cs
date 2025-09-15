using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvImportDemo.Models;
using CsvImportDemo.Repositories;
using CsvImportDemo.Services;
using CsvImportDemo.Validators;
using Moq;
using Xunit;

namespace CsvImportDemo.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task ValidateAndParseCsvAsync_ValidAndInvalidRows_ReturnsValidAndErrors()
        {
            // Arrange
            var csv = "Name,Price,Quantity\nValidProduct,10.5,5\n,20,2\nInvalidPrice,-5,1";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));
            var repoMock = new Mock<IProductRepository>();
            var validator = new ProductValidator();
            var service = new ProductService(repoMock.Object, validator);

            // Act
            var (validProducts, errors) = await service.ValidateAndParseCsvAsync(stream);

            // Assert
            Assert.Single(validProducts);
            Assert.Equal("ValidProduct", ((List<Product>)validProducts)[0].Name);
            Assert.Equal(2, ((List<string>)errors).Count);
        }

        [Fact]
        public async Task SaveProductsAsync_CallsRepositoryAddProducts()
        {
            // Arrange
            var repoMock = new Mock<IProductRepository>();
            var validatorMock = new Mock<IProductValidator>();
            var service = new ProductService(repoMock.Object, validatorMock.Object);
            var products = new List<Product>
            {
                new Product { Name = "Test", Price = 10, Quantity = 5 }
            };

            // Act
            await service.SaveProductsAsync(products);

            // Assert
            repoMock.Verify(r => r.AddProductsAsync(products), Times.Once);
        }

        [Fact]
        public async Task GetAllProductsAsync_CallsRepositoryGetAllProducts()
        {
            // Arrange
            var repoMock = new Mock<IProductRepository>();
            var validatorMock = new Mock<IProductValidator>();
            var service = new ProductService(repoMock.Object, validatorMock.Object);
            var expectedProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Test", Price = 10, Quantity = 5 }
            };
            repoMock.Setup(r => r.GetAllProductsAsync()).ReturnsAsync(expectedProducts);

            // Act
            var result = await service.GetAllProductsAsync();

            // Assert
            repoMock.Verify(r => r.GetAllProductsAsync(), Times.Once);
            Assert.Single(result);
            Assert.Equal("Test", result.First().Name);
        }
    }
}
