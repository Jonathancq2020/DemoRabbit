using DemoRabbitMq.Consumer.Consumers;
using DemoRabbitMq.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices();

builder.Services.AddHostedService<TiendaConsumer>();
builder.Services.AddHostedService<CompraConsumer>();
builder.Services.AddHostedService<NotificarCompraConsumer>();

var app = builder.Build();


app.Run();
