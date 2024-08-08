using Microsoft.EntityFrameworkCore;
using ORMTask.Contexts;
using ORMTask.Models;

namespace ORMTask.Services
{
    public class ProductService
    {
        public async Task CreateAsync(Product product)
        {
            AppDbContext context = new AppDbContext();
            //Product product = new Product
            //{
            //    Name = "Spagetti",
            //    Price = 15
            //};
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }
        public async Task<List<Product>> GetAllAsync()
        {
            AppDbContext context = new AppDbContext();
            return await context.Products.ToListAsync();
        }

    }
}
