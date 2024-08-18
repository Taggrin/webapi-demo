using WebAPIDemo.Entities;
using WebAPIDemo.Models;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponse>> GetProducts()
        {
            return (await productRepository.GetAll()).Select(MapProductToReponse);
        }


        public async Task<ProductResponse?> GetProductByID(int id)
        {
            var result = await productRepository.GetByID(id);
            if (result == null)
                return null;

            return MapProductToReponse(result);
        }

        public async Task<bool> AddProduct(AddProductRequest request)
        {
            if (string.IsNullOrEmpty(request.Description))
                return false;
            if (request.Price < 0)
                return false;

            var result = await productRepository.Add(new Product
            {
                Description = request.Description,
                Price = request.Price,
                Modified = DateTime.UtcNow
            });

            return result != null;
        }

        public async Task<bool> UpdateProduct(int id, UpdateProductRequest request)
        {
            var current = await productRepository.GetByID(id);
            if (current == null)
                return false;

            if (!string.IsNullOrEmpty(request.Description))
                current.Description = request.Description;
            if (request.Price.HasValue && request.Price.Value >= 0)
                current.Price = request.Price.Value;
            current.Modified = DateTime.UtcNow;

            var result = await productRepository.Update(current);
            return result != null;
        }

        public async Task<bool> Delete(int id)
        {
            var current = await productRepository.GetByID(id);
            if (current == null)
                return false;

            return await productRepository.Delete(current);
        }

        private ProductResponse MapProductToReponse(Product product)
        {
            // In this case not really needed due to no 'secret' fields, but entities should not be directly exposed to the controllers.
            return new ProductResponse
            {
                ID = product.ID,
                Description = product.Description,
                Price = product.Price,
                Modified = product.Modified
            };
        }
    }
}
