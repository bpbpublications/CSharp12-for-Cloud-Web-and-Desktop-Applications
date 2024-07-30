// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");
string connectionString = "Endpoint=sb://thiagosample.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=e6Bb5GnhuadJfa1W49kCxwfBztioIAHXU+ASbH7kjrc=";
string queueName = "samplequeue";


ServiceBusClient client = new ServiceBusClient(connectionString);

// create a receiver that we can use to receive the messages
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
// a batch of messages (maximum of 4 in this case) are received
IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages: 4);
Console.WriteLine("Number of messages in the batch: " + receivedMessages.Count);

// go through each of the messages received
foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
{
    // get the message body as a string
    string body = receivedMessage.Body.ToString();
    Console.WriteLine(body);
}

await client.DisposeAsync();
await receiver.DisposeAsync();