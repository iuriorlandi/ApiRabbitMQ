using ApiRabbitMQ.Models;

namespace ApiRabbitMQ.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductList();
        Product GetProductById(int id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
