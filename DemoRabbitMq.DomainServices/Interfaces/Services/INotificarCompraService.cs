using DemoKafka.DomainModel.Entities;

namespace DemoRabbitMq.DomainServices.Interfaces.Services
{
    public interface INotificarCompraService
    {
        Task Handle(Order order);
    }
}
