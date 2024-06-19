using RabbitMQ.Client;

namespace Multishop.RabbitMQApi.Services
{
    public interface IRabbitMQService
    {
        public IConnection CreateConnection();

        public IModel CreateChannel();

        public void QueueDeclare(string queueName);

        public void BasicPublish(string queueName, string messageContent);
    }
}
