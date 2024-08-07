using ORMTask.Models;
using ORMTask.Services;

ProductService productService = new ProductService();
Product product = new Product
{
    Name = "Spagetti",
    Price = 15
};
await productService.CreateAsync(product);