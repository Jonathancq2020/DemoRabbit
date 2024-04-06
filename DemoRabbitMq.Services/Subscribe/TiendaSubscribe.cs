using DemoKafka.DomainModel.Entities;
using DemoRabbitMq.DomainServices.Interfaces.Services;
using DemoRabbitMq.Services.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DemoRabbitMq.Services.Subscribe
{
    internal class TiendaSubscribe :
        ITiendaSubscribe
    {
        readonly ConnectionRabbitMq ConnectionRabbitMq;
        readonly ConnectionFactory ConnectionFactory;
        readonly IModel Channel;
        readonly IServiceScopeFactory ServiceScopeFactory;

        public TiendaSubscribe(
            IServiceScopeFactory serviceScopeFactory,
            IConfiguration configuration)
        {
            ServiceScopeFactory = serviceScopeFactory;
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
                VirtualHost = ConnectionRabbitMq.VirtualHost,
                DispatchConsumersAsync = true
            };

            var connection = ConnectionFactory.CreateConnection();
            Channel = connection.CreateModel();

            Channel.ExchangeDeclare(
                exchange: ConfigurationRabbitMQ.EXCHANGE_NAME,
                type: ExchangeType.Direct
                );
        }

        public void Subscribe()
        {
            string EventName = $"TIENDA.{typeof(Order).Name}";

            var queue = Channel.QueueDeclare("TIENDA", false, false, false, null);
            Channel.QueueBind(queue, ConfigurationRabbitMQ.EXCHANGE_NAME, EventName);

            var consumer = new AsyncEventingBasicConsumer(Channel);

            consumer.Received += async (sender, evenArgs) =>
            {
                var conectArray = evenArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(conectArray);
                Order EventObject =
                    (Order)JsonSerializer.Deserialize(contentString,
                    typeof(Order));

                using (var scope = ServiceScopeFactory.CreateScope())
                {
                    var handler = scope.ServiceProvider
                                       .GetService<IValidateProductStockService>();

                    await handler.Handle(EventObject);
                }
            };
            Channel.BasicConsume("TIENDA", true, consumer);
        }
    }
}
