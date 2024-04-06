using DemoKafka.DomainModel.Entities;
using DemoRabbitMq.DomainServices.Interfaces.Services;

namespace DemoRabbitMq.Services.Services
{
    internal class NotificarCompraService : INotificarCompraService
    {
        readonly INotificarCompraProducer NotificarCompraProducer;

        public NotificarCompraService(INotificarCompraProducer notificarCompraProducer)
        {
            NotificarCompraProducer = notificarCompraProducer;
        }

        public Task Handle(Order order)
        {
            Console.WriteLine("NOTIFICANDO...");
            order.Id = new Random().Next();
            NotificarCompraProducer.Publish(order);

            return Task.CompletedTask;
        }
    }
}
