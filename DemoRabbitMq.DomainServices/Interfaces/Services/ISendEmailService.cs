using DemoKafka.DomainModel.Entities;

namespace DemoRabbitMq.DomainServices.Interfaces.Services
{
    public interface ISendEmailService
    {
        Task SendEmail(Order order);
    }
}
