
using DemoRabbitMq.DomainServices.Interfaces.Services;

namespace DemoRabbitMq.Consumer.Consumers
{
    public class TiendaConsumer : BackgroundService
    {
        readonly ITiendaSubscribe TiendaSubscribe;

        public TiendaConsumer(ITiendaSubscribe tiendaSubscribe)
        {
            TiendaSubscribe = tiendaSubscribe;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TiendaSubscribe.Subscribe();

            return Task.CompletedTask;
        }
    }
}
