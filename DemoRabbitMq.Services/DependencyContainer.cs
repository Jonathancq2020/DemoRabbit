using DemoRabbitMq.DomainServices.Interfaces.Services;
using DemoRabbitMq.Services.Plublish;
using DemoRabbitMq.Services.Services;
using DemoRabbitMq.Services.Subscribe;
using Microsoft.Extensions.DependencyInjection;

namespace DemoRabbitMq.Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ITiendaSubscribe, TiendaSubscribe>();
            services.AddSingleton<ICompraSubscribe, CompraSubscribe>();
            services.AddSingleton<INotificarCompraSubscribe, NotificarCompraSubscribe>();

            services.AddTransient<ITiendaProducer, TiendaProducer>();
            services.AddTransient<ICompraProducer, CompraProducer>();
            services.AddTransient<INotificarCompraProducer, NotificarCompraProducer>();

            services.AddScoped<IValidateProductStockService, ValidateProductStockService>();
            services.AddScoped<INotificarCompraService, NotificarCompraService>();
            services.AddScoped<ISendEmailService, SendEmailService>();

            return services;
        }
    }
}
