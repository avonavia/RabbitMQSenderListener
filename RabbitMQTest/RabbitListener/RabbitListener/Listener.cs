using System.Text;
using RabbitMQ.Client;
using System;
using RabbitMQ.Client.Events;
using System.Threading;
using Nest;

namespace RabbitListener
{
    public static class Listener
    {
        public static void Listen(IModel channel)
        {
            while (true)
            {
                Console.WriteLine("Listening...");
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var recieved = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Recieved: " + recieved);
                };
                channel.BasicConsume(queue: "messages",
                                     autoAck: true,
                                     consumer: consumer);
                Thread.Sleep(5000);
            }
        }
    }
}
