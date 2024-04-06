using DemoKafka.DomainModel.Entities;
using DemoRabbitMq.DomainServices.Interfaces.Services;

namespace DemoRabbitMq.Services.Services
{
    internal class ValidateProductStockService : IValidateProductStockService
    {
        readonly ICompraProducer CompraProducer;

        public ValidateProductStockService(ICompraProducer compraProducer)
        {
            CompraProducer = compraProducer;
        }

        public Task Handle(Order order)
        {
            Console.WriteLine("VALIDANDO...");
            Boolean flag = false;

            foreach (var item in order.OrderDetails)
            {
                if (item.Quantity <= 0)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                CompraProducer.Publish(order);
            }

            return Task.CompletedTask;
        }
    }
}
