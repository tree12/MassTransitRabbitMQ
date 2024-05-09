using Newtonsoft.Json;
using Producer.RabbitMQ.Connection;
using RabbitMQ.Client;
using System.Text;

namespace Producer.RabbitMQ
{
    public class RabbitMQProducer : IMessageProducer
    {
        private readonly IRabbitMqConnection _connection;
        public RabbitMQProducer(IRabbitMqConnection connection )
        {
            _connection = connection;
        }
        public void SendMessage<T>(T message)
        {

            using var channel = _connection.Connection.CreateModel();
            channel.QueueDeclare("purchases", exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "purchases", body: body);
        }
    }
}
