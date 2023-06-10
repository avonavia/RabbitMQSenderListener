using RabbitMQ.Client;
using System;

namespace RabbitMQTest
{
    public static class Controls
    {
        public static void Control(IModel channel)
        {
            while (true)
            {
                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        Sender.Send(channel);
                        break;
                }
            }
        }
    }
}
