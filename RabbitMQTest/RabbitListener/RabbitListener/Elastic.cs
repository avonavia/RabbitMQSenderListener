using System;
using Nest;

namespace RabbitListener
{
    public static class Elastic
    {
        public static ElasticClient Connect()
        {
            var settings = new ConnectionSettings(new Uri("http://elk.astepanov.space:9200")).DefaultIndex("demo-messages");

            var client = new ElasticClient(settings);

            return client;
        }
        public static void Create(ElasticClient client)
        {
            if (!client.Indices.Exists("demo-messages").Exists)
            {
                client.Indices.Create("demo-messages", index => index);
            }
            else
            {
                Console.WriteLine("\nIndex created OR already exists");
            }
        }

        public static void Add(ElasticClient client, string message)
        {
            client.IndexDocument(message);
        }

        public static void ShowAll(ElasticClient client)
        {
            Console.WriteLine("\n");
            if (client.Indices.Exists("demo-messages").Exists)
            {
                Console.WriteLine("Result:");
                var searchResponse = client.Search<string>(s => s);

                var foundmessages = searchResponse.Documents;

                foreach (var mes in foundmessages)
                {
                    Console.WriteLine($"Message: {mes}");
                }
            }
            else
            {
                Console.WriteLine("Index doesn't exist");
            }
        }
    }
}
