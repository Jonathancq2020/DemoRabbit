using DemoKafka.DomainModel.Entities;

namespace DemoRabbitMq.DomainServices.Interfaces.Services
{
    public interface ITiendaProducer
    {
        void Publish(Order order);
    }
}
