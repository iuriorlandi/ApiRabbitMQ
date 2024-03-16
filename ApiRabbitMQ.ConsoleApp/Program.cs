﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};

var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.QueueDeclare("product", false, false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, enventArgs) =>
{
    var body = enventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Product message received: {message}");
};

channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);

Console.ReadKey();