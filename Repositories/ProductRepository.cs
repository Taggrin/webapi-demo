using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Entities;

namespace WebAPIDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<Product?> Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Products.ToArrayAsync();
        }

        public async Task<Product?> GetByID(int id)
        {
            return await context.Products.SingleOrDefaultAsync(p => p.ID == id);
        }

        public Task<Product?> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
