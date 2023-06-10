using RabbitMQ.Client;

namespace RabbitListener
{
    class Program
    {
        static void Main()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            Listener.Listen(channel);
        }
    }
}
