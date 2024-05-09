// See https://aka.ms/new-console-template for more information

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Data.Common;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};
var connection = factory.CreateConnection();

using var channel = connection.CreateModel();
channel.QueueDeclare("purchases", exclusive: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Message received: {message}");
};
channel.BasicConsume(queue: "purchases", autoAck: true, consumer: consumer);
Console.ReadKey();
