using DemoKafka.DomainModel.Entities;
using DemoRabbitMq.DomainServices.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace DemoRabbitMq.Services.Services
{
    internal class SendEmailService : ISendEmailService
    {
        readonly IConfiguration Configuration;
        public SendEmailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Task SendEmail(Order order)
        {
            Console.WriteLine("ENVIANDO EMAIL...");

            string remitente = Configuration["Mail:From"];
            string password = Configuration["Mail:Password"];

            var smtpClient = new SmtpClient(Configuration["Mail:Smtp"])
            {
                Port = int.Parse(Configuration["Mail:Port"]),
                Credentials = new NetworkCredential(remitente, password),
                EnableSsl = true,
            };

            var correo = new MailMessage(remitente, Configuration["Mail:To"])
            {
                Subject = "COMPRA REALIZADA",
                Body = $"Usted ha realizado una compra, su codigo de la orden de compra es {order.Id}",
            };

            try
            {
                smtpClient.Send(correo);
                Console.WriteLine("Correo electrónico enviado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
