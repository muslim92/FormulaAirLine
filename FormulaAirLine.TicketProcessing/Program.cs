﻿// See https://aka.ms/new-console-template for more information

using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;

Console.WriteLine("Welcome to the Ticketing Service!");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "user",
    Password = "mypass",
    VirtualHost = "/"
};

var conn = factory.CreateConnection();

using var channel = conn.CreateModel();

channel.QueueDeclare("bookings", durable: true, exclusive: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{
    //getting my byte[]
    var body = eventArgs.Body.ToArray();

    var message = Encoding.UTF8.GetString(body);
    
    Console.WriteLine($"New ticket processing is initiated for - {message}");

};

channel.BasicConsume("bookings", true, consumer);

Console.ReadKey();
