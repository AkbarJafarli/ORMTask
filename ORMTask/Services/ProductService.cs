using Microsoft.EntityFrameworkCore;
using ORMTask.Contexts;
using ORMTask.Exceptions;
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

        public async Task<Product> GetById(int id)
        {
            AppDbContext context = new AppDbContext();
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) throw new NotFoundException("Id not found");
            return product;
        }

        public async Task Update(Product product)
        {
            AppDbContext context = new AppDbContext();
            var dbProduct = await context.Products.FirstOrDefaultAsync(p=>p.Id == product.Id);
            if (dbProduct == null)
            {
                throw new NotFoundException($"Product not found by id {product.Id}");
            }
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AppDbContext context = new AppDbContext();
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new NotFoundException($"Product not found by id {id}");
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

    }
}
