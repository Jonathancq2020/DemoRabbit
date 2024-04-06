using DemoKafka.DomainModel.Entities;

namespace DemoRabbitMq.DomainServices.Interfaces.Services
{
    public interface IValidateProductStockService
    {
        Task Handle(Order order);
    }
}
