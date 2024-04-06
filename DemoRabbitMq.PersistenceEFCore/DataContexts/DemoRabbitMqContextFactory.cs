using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DemoKafka.PersistenceEFCore.DataContexts
{
    internal class DemoRabbitMqContextFactory :
        IDesignTimeDbContextFactory<DemoRabbitMqContext>
    {
        //Add-Migration AddDemoKafka -p DemoKafka.PersistenceEFCore -s DemoKafka.PersistenceEFCore -c DemoKafkaContextFactory
        //Update-Database -p DemoKafka.PersistenceEFCore -s DemoKafka.PersistenceEFCore -context DemoKafkaContextFactory
        public DemoRabbitMqContext CreateDbContext(string[] args)
        {
            var OptionBuilder =
            new DbContextOptionsBuilder<DemoRabbitMqContext>();

            OptionBuilder
                .UseMySQL("server=localhost;port=3307;database=TareaKafka;user=root;password=DemoKafka#2024");

            return new DemoRabbitMqContext(OptionBuilder.Options);
        }
    }
}
