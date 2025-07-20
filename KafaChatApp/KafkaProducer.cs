using Confluent.Kafka;
using System;
using System.Threading.Tasks;

class KafkaProducer
{
    public static async Task Main(string[] args)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        Console.WriteLine("Kafka Producer started. Type messages to send:");

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        while (true)
        {
            string message = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(message)) continue;

            var result = await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
            Console.WriteLine($"Sent: '{message}' to {result.TopicPartitionOffset}");
        }
    }
}
