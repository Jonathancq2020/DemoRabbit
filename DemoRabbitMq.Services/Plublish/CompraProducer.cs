using DemoKafka.DomainModel.Entities;
using DemoRabbitMq.DomainServices.Interfaces.Services;
using DemoRabbitMq.Services.Configuration;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text.Json;

namespace DemoRabbitMq.Services.Plublish
{
    internal class CompraProducer : ICompraProducer
    {
        readonly ConnectionRabbitMq ConnectionRabbitMq;
        readonly ConnectionFactory ConnectionFactory;

        public CompraProducer(IConfiguration configuration)
        {
            ConnectionRabbitMq = new ConnectionRabbitMq
            {
                HostName = configuration["RabbitMQ:HostName"],
                UserName = configuration["RabbitMQ:UserName"],
                Password = configuration["RabbitMQ:Password"],
                VirtualHost = configuration["RabbitMQ:VirtualHost"],
                Port = int.Parse(configuration["RabbitMQ:Port"])
            };

            ConnectionFactory = new ConnectionFactory()
            {
                HostName = ConnectionRabbitMq.HostName,
                Port = ConnectionRabbitMq.Port,
                UserName = ConnectionRabbitMq.UserName,
                Password = ConnectionRabbitMq.Password,
                VirtualHost = ConnectionRabbitMq.VirtualHost
            };
        }
        public void Publish(Order order)
        {
            using (var connection = ConnectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    MemoryStream message = new();
                    JsonSerializer.Serialize(message, order);
                    var body = message.ToArray();

                    channel.BasicPublish(
                        exchange: ConfigurationRabbitMQ.EXCHANGE_NAME,
                        routingKey: $"COMPRA.{order.GetType().Name}",
                        basicProperties: null,
                        body: body
                        );
                }
            }
        }
    }
}
