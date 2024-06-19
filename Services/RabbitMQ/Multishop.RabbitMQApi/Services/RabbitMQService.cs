using RabbitMQ.Client;
using System.Text;

namespace Multishop.RabbitMQApi.Services
{
    public class RabbitMQService: IRabbitMQService
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

        public void BasicPublish(string queueName, string messageContent)
        {

            var channel = CreateChannel();
            var byteMessage = Encoding.UTF8.GetBytes(messageContent);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: byteMessage);
        }


    }
}
