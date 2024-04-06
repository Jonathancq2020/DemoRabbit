using DemoKafka.Application.Dtos.RegisterOrder;
using DemoKafka.DomainModel.Entities;
using DemoRabbitMq.DomainServices.Interfaces.Services;
using MediatR;

namespace DemoKafka.Application.UseCases
{
    internal class RegisterOrderUseCase : IRequestHandler<RegisterOrderRequestDto>
    {
        readonly ITiendaProducer TiendaProducer;

        public RegisterOrderUseCase(ITiendaProducer tiendaProducer)
        {
            TiendaProducer = tiendaProducer;
        }

        public Task Handle(RegisterOrderRequestDto request, CancellationToken cancellationToken)
        {
            Order NewOrder = new Order()
            {
                ClientName = request.ClientName,
                DocumentNumber = request.DocumentNumber,
                DocumentTypeId = request.DocumentTypeId,
                ReceiptType = request.ReceiptType,
                RegisterDate = request.RegisterDate,
                SubTotal = request.SubTotal,
                Total = request.Total,
                Igv = request.Igv,
                StateId = 1,
                OrderDetails = request.OrderDetail.Select(x => new OrderDetail(x.ProductId, x.Quantity, x.UnitPrice)).ToList()
            };

            TiendaProducer.Publish(NewOrder);

            return Task.CompletedTask;
        }
    }
}
