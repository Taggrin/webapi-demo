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

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Products.ToArrayAsync();
        }

        public async Task<Product?> GetByID(int id)
        {
            return await context.Products.SingleOrDefaultAsync(p => p.ID == id);
        }

        public async Task<Product?> Add(Product product)
        {
            await context.Products.AddAsync(product);
            var result = await context.SaveChangesAsync();
            return result > 0 ? product : null;
        }

        public async Task<Product?> Update(Product product)
        {
            var result = await context.SaveChangesAsync();
            return result > 0 ? product : null;
        }

        public async Task<bool> Delete(Product product)
        {
            context.Products.Remove(product);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
