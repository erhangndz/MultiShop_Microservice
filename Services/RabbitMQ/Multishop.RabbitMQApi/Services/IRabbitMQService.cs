using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Multishop.RabbitMQApi.Services
{
    public interface IRabbitMQService
    {
        public IConnection CreateConnection();

        public IModel CreateChannel();

        public void QueueDeclare(string queueName);

        public void BasicPublish(string queueName, string messageContent);

        public EventingBasicConsumer CreateConsumer();

        public string Consume(string queueName);
    }
}
