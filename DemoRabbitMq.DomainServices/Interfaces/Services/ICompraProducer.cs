using DemoKafka.DomainModel.Entities;

namespace DemoRabbitMq.DomainServices.Interfaces.Services
{
    public interface ICompraProducer
    {
        void Publish(Order order);
    }
}
