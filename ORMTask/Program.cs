using ORMTask.Models;
using ORMTask.Services;

ProductService productService = new ProductService();
//Product product = new Product
//{
//    Name = "Spagetti",
//    Price = 15
//};
//await productService.CreateAsync(product);

List<Product> products = await productService.GetAllAsync();

foreach (Product product in products)
{
    Console.WriteLine($"Id:{product.Id} - Name:{product.Name} - Price:{product.Price}");
}