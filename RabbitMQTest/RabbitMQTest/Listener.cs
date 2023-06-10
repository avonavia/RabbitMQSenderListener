using System.Text;
using RabbitMQ.Client;
using System;
using RabbitMQ.Client.Events;

namespace RabbitMQTest
{
    public static class Listener
    {
        public static void Listen(IModel channel)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var recieved = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Received: {recieved}");
            };
            channel.BasicConsume(queue: "message",
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
