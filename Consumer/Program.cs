using Confluent.Kafka;
using Consumer;
using Consumer.Models;
using System.Text.Json;

JsonSerializerOptions options = new()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

ConsumerConfig config = new()
{
    GroupId = "DataTransfer",
    BootstrapServers = "localhost:29092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using IConsumer<Ignore, string> consumer = new ConsumerBuilder<Ignore, string>(config).Build();
consumer.Subscribe("datatransfer.cw.quote");

CancellationTokenSource source = new();
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true;
    source.Cancel();
};

while (true)
{
    ConsumeResult<Ignore, string> result = consumer.Consume(source.Token);
    Console.WriteLine($"Topic Name : {result.TopicPartitionOffset}");
    Console.WriteLine($"Message : {result.Value}");

    if (string.IsNullOrEmpty(result.Value))
        continue;

    Result<Quote>? result1 = JsonSerializer.Deserialize<Result<Quote>>(result.Value, options);
}