using RabbitMQ.Client;

namespace Multishop.RabbitMQApi.Services
{
    public class RabbitMQService
    {
        public IConnection CreateConnection()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",

            };
            var connection = connectionFactory.CreateConnection();
            return connection;

           
        }

        public IModel CreateChannel()
        {
            var connection = CreateConnection();
            var channel = connection.CreateModel();
            return channel;
        }

        public void QueueDeclare(string queueName)
        {
            var channel = CreateChannel();
            channel.QueueDeclare(queueName, false, false, false, null);
        }


    }
}
