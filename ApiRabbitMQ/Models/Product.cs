﻿namespace ApiRabbitMQ.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
    }
}
