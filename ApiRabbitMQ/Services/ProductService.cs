﻿using ApiRabbitMQ.Context;
using ApiRabbitMQ.Models;
using ApiRabbitMQ.RabbitMQ;

namespace ApiRabbitMQ.Services
{
    public class ProductService(AppDbContext context, IRabbitMQProducer rabbitMQProducer) : IProductService
    {
        private readonly AppDbContext _context = context;
        private readonly IRabbitMQProducer _rabbitMQProducer = rabbitMQProducer;

        public Product AddProduct(Product product)
        {
            var result = _context.Products.Add(product);
            _context.SaveChanges();

            _rabbitMQProducer.SendProductMessage(result.Entity);

            return result.Entity;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            var result = _context.Products.Remove(product);
            _context.SaveChanges();

            return result != null;
        }

        public Product GetProductById(int id) 
            => _context.Products.FirstOrDefault(p => p.Id == id);
        

        public IEnumerable<Product> GetProductList() 
            => [.. _context.Products];

        public Product UpdateProduct(Product product)
        {
            var productUpdated = _context.Products.Update(product);
            return productUpdated.Entity;
        }
    }
}
