using RabbitMQ.Client;
using System;

namespace RabbitMQTest
{
    class Program
    {
        static void Main()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            Console.WriteLine("To Send press: 1");

            Controls.Control(channel);
        }
    }
}
