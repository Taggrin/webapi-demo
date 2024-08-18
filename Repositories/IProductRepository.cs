using WebAPIDemo.Entities;

namespace WebAPIDemo.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetByID(int id);
        Task<Product?> Add(Product product);
        Task<Product?> Update(Product product);
        Task<bool> Delete(int id);
    }
}
