using RabbitMQ.Client;

namespace DemoRabbitMq.Services.Configuration
{
    internal class ConnectionRabbitMq
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public int Port { get; set; } = AmqpTcpEndpoint.UseDefaultPort;
    }
}
