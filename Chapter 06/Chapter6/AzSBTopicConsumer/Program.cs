// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");
string connectionString = "Endpoint=sb://thiagosample.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=e6Bb5GnhuadJfa1W49kCxwfBztioIAHXU+ASbH7kjrc=";
string topicName = "sampletopic";
string subscriptionName = "samplesubscription";


ServiceBusClient client = new ServiceBusClient(connectionString);

// create a receiver that we can use to receive the message// create a receiver for our subscription that we can use to receive the message
ServiceBusReceiver receiver = client.CreateReceiver(topicName, subscriptionName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// get the message body as a string
string body = receivedMessage.Body.ToString();
Console.WriteLine(body);


await client.DisposeAsync();
await receiver.DisposeAsync();