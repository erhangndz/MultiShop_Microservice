using Microsoft.AspNetCore.Http.HttpResults;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Multishop.RabbitMQApi.Services
{
    public class RabbitMQService(): IRabbitMQService
    {
        private static string _message;
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

        public EventingBasicConsumer CreateConsumer()
        {
            var channel = CreateChannel();
            var consumer = new EventingBasicConsumer(channel);
            return consumer;
        }

        
        public string Consume(string queueName)
        {
            var consumer = CreateConsumer();

            consumer.Received += (model, body) =>
            {
                var byteMessage = body.Body.ToArray();
                _message = Encoding.UTF8.GetString(byteMessage);
                
            };
            

            var channel = CreateChannel();
            channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

            if (string.IsNullOrEmpty(_message))
            {
                return "";
            }

            return _message;
        }


    }
}
