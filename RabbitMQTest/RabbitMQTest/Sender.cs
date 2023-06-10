using System.Text;
using RabbitMQ.Client;
using System;

namespace RabbitMQTest
{
    public static class Sender
    {
        public static void Send(IModel channel)
        {
            channel.QueueDeclare(queue: "messages",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            Random rand = new Random();

                string message = "Message code: " + rand.Next(100).ToString();
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "messages",
                                     basicProperties: null,
                                     body: body);

            Console.WriteLine("Sent message");
        }
    }
}
