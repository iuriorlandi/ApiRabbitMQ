using ApiRabbitMQ.Models;
using ApiRabbitMQ.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet("producs-list")]
        public IActionResult ProductsList()
        {
             var products = _productService.GetProductList();
            return Ok(products);
        }

        [HttpGet]
        public IActionResult ProductById(int id) 
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var storedProduct = _productService.AddProduct(product);
            return Ok(storedProduct);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var updatedProduct = _productService.UpdateProduct(product);
            return Ok(updatedProduct);
        }
    }
}
