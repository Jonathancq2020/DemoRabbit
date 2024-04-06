using DemoKafka.DomainServices.Interfaces.Repositories;
using DemoKafka.PersistenceEFCore.DataContexts;
using NotificationMessage = DemoKafka.PersistenceEFCore.Entities.NotificationMessage;

namespace DemoKafka.PersistenceEFCore.Repositories
{
    internal class RegisterNotificationMessageRepository : IRegisterNotificationMessageRepository
    {
        readonly DemoRabbitMqContext Context;

        public RegisterNotificationMessageRepository(DemoRabbitMqContext context)
        {
            Context = context;
        }

        public async Task Register(DomainModel.ValueObjects.NotificationMessage notificationMessage)
        {
            await Context.NotificationMessages.AddAsync(new NotificationMessage
            {
                Message = notificationMessage.Message,
                CreatedDate = notificationMessage.CreatedDate
            });

            await Context.SaveChangesAsync();
        }
    }
}
