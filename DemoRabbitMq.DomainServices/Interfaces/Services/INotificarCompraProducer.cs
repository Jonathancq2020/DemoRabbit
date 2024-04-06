using DemoKafka.DomainModel.Entities;

namespace DemoRabbitMq.DomainServices.Interfaces.Services
{
    public interface INotificarCompraProducer
    {
        void Publish(Order order);
    }
}
