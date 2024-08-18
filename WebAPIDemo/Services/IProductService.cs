using WebAPIDemo.Models;

namespace WebAPIDemo.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetProducts();
        Task<ProductResponse?> GetProductByID(int id);
        Task<bool> AddProduct(AddProductRequest request);
        Task<bool> UpdateProduct(int id, UpdateProductRequest request);
        Task<bool> Delete(int id);
    }
}
