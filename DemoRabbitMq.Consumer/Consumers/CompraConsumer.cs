
using DemoRabbitMq.DomainServices.Interfaces.Services;

namespace DemoRabbitMq.Consumer.Consumers
{
    public class CompraConsumer : BackgroundService
    {
        readonly ICompraSubscribe CompraSubscribe;

        public CompraConsumer(ICompraSubscribe compraSubscribe)
        {
            CompraSubscribe = compraSubscribe;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            CompraSubscribe.Subscribe();

            return Task.CompletedTask;
        }
    }
}
