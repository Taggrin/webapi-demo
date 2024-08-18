using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPIDemo.Controllers;
using WebAPIDemo.Models;
using WebAPIDemo.Services;

namespace WebAPIDemo.Tests
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> mockProductService;
        private readonly ProductController productController;

        public ProductControllerTests()
        {
            mockProductService = new Mock<IProductService>();
            productController = new ProductController(mockProductService.Object);
        }

        [Fact]
        public async Task GetProducts_ReturnsOk_WithProducts()
        {
            var products = new ProductResponse[]
            {
                new ProductResponse()
            };
            mockProductService.Setup(x => x.GetProducts()).ReturnsAsync(products);

            var result = await productController.GetProducts();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetProduct_ReturnsOk_WhenProductExists()
        {
            mockProductService.Setup(service => service.GetProductByID(It.IsAny<int>())).ReturnsAsync(new ProductResponse());

            var result = await productController.GetProduct(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetProduct_ReturnsNotFound_WhenProductDoesNotExist()
        {
            mockProductService.Setup(service => service.GetProductByID(It.IsAny<int>())).ReturnsAsync((ProductResponse)null!);

            var result = await productController.GetProduct(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddProduct_ReturnsOk_WhenSucceeded()
        {
            mockProductService.Setup(service => service.AddProduct(It.IsAny<AddProductRequest>())).ReturnsAsync(true);

            var result = await productController.AddProduct(new AddProductRequest());

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task AddProduct_ReturnsBadRequest_WhenFailed()
        {
            mockProductService.Setup(service => service.AddProduct(It.IsAny<AddProductRequest>())).ReturnsAsync(false);

            var result = await productController.AddProduct(new AddProductRequest());

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateProduct_ReturnsOk_WhenProductExists()
        {
            mockProductService.Setup(service => service.UpdateProduct(It.IsAny<int>(), It.IsAny<UpdateProductRequest>())).ReturnsAsync(true);

            var result = await productController.UpdateProduct(1, new UpdateProductRequest());

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateProduct_ReturnsNotFound_WhenProductDoesNotExist()
        {
            mockProductService.Setup(service => service.UpdateProduct(It.IsAny<int>(), It.IsAny<UpdateProductRequest>())).ReturnsAsync(false);

            var result = await productController.UpdateProduct(1, new UpdateProductRequest());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsOk_WhenProductExists()
        {
            mockProductService.Setup(service => service.Delete(It.IsAny<int>())).ReturnsAsync(true);

            var result = await productController.DeleteProduct(1);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsNotFound_WhenProductDoesNotExist()
        {
            mockProductService.Setup(service => service.Delete(It.IsAny<int>())).ReturnsAsync(false);

            var result = await productController.DeleteProduct(1);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}