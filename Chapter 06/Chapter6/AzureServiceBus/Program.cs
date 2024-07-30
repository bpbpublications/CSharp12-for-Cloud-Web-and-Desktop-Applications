// See https://aka.ms/new-console-template for more information
using Azure.Core;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using System;
using System.Threading.Tasks;

Console.WriteLine("Hello, World!");
string connectionString = "Endpoint=sb://thiagosample.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=e6Bb5GnhuadJfa1W49kCxwfBztioIAHXU+ASbH7kjrc=";
string queueName = "samplequeue";
string sessionQueueName = "samplesessionqueue";
string topicName = "sampletopic";

// name of your Service Bus queue
// the client that owns the connection and can be used to create senders and receivers
// the sender used to publish messages to the queue

await using var client =new ServiceBusClient(connectionString);
await using var normalQueueSender = client.CreateSender(queueName);
await using var sessionQueueSender = client.CreateSender(sessionQueueName);
await using var topicQueueSender = client.CreateSender(topicName);

await normalQueueSender.SendMessageAsync(new ServiceBusMessage("1 message at: " + DateTime.Now));
await normalQueueSender.SendMessageAsync(new ServiceBusMessage("2 message at: " + DateTime.Now));
await normalQueueSender.SendMessageAsync(new ServiceBusMessage("3 message at: " + DateTime.Now));

// create a batch 
using ServiceBusMessageBatch messageBatch = await normalQueueSender.CreateMessageBatchAsync();

for (int i = 1; i <= new Random().Next(10); i++)
{
    // try adding a message to the batch
    if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i} at: " + DateTime.Now)))
    {
        // if it is too large for the batch
        throw new Exception($"The message {i} is too large to fit in the batch.");
    }
}
await normalQueueSender.SendMessagesAsync(messageBatch);

await topicQueueSender.SendMessageAsync(new ServiceBusMessage("1 topic message at: " + DateTime.Now));
await topicQueueSender.SendMessageAsync(new ServiceBusMessage("2 topic message at: " + DateTime.Now));
await topicQueueSender.SendMessageAsync(new ServiceBusMessage("3 topic message at: " + DateTime.Now));

await sessionQueueSender.SendMessageAsync(new ServiceBusMessage("1 session message at: " + DateTime.Now) { SessionId = "sampleSessionId" });
await sessionQueueSender.SendMessageAsync(new ServiceBusMessage("2 session message at: " + DateTime.Now) { SessionId = "sampleSessionId" });
await sessionQueueSender.SendMessageAsync(new ServiceBusMessage("3 session message at: " + DateTime.Now) { SessionId = "sampleSessionId" });
await sessionQueueSender.SendMessageAsync(new ServiceBusMessage("1 session message at: " + DateTime.Now) { SessionId = "sampleSessionId2" });
await sessionQueueSender.SendMessageAsync(new ServiceBusMessage("2 session message at: " + DateTime.Now) { SessionId = "sampleSessionId2" });
await sessionQueueSender.SendMessageAsync(new ServiceBusMessage("3 session message at: " + DateTime.Now) { SessionId = "sampleSessionId2" });

Console.WriteLine("Messages Published!");