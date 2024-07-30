// See https://aka.ms/new-console-template for more information

using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");
string connectionString = "Endpoint=sb://thiagosample.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=e6Bb5GnhuadJfa1W49kCxwfBztioIAHXU+ASbH7kjrc=";
string sessionQueueName = "samplesessionqueue";

ServiceBusClient client = new ServiceBusClient(connectionString);

// create a receiver specifying a particular session
ServiceBusSessionReceiver receiver = await client.AcceptSessionAsync(sessionQueueName, "sampleSessionId");

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
Console.WriteLine("Session Id: " + receivedMessage.SessionId);
Console.WriteLine("Body" + receivedMessage.Body);

// we can also set arbitrary session state using this receiver
// the state is specific to the session, and not any particular message
await receiver.SetSessionStateAsync(new BinaryData("brand new state"));

// complete the message, thereby deleting it from the service
await receiver.CompleteMessageAsync(receivedMessage);

await client.DisposeAsync();
await receiver.DisposeAsync();