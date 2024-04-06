using DemoRabbitMq.DomainServices.Interfaces.Services;

namespace DemoRabbitMq.Consumer.Consumers
{
    public class NotificarCompraConsumer : BackgroundService
    {
        readonly INotificarCompraSubscribe NotificarCompraSubscribe;

        public NotificarCompraConsumer(INotificarCompraSubscribe notificarCompraSubscribe)
        {
            NotificarCompraSubscribe = notificarCompraSubscribe;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            NotificarCompraSubscribe.Subscribe();

            return Task.CompletedTask;
        }
    }
}
