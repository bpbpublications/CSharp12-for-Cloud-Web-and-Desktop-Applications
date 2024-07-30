// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

Console.WriteLine("Hello, World!");
var factory = new ConnectionFactory() { HostName = "localhost" };
string queueName = "weatherForecastSampleQueue";
using (var rabbitMqConnection = factory.CreateConnection())
{

    using (var rabbitMqChannel = rabbitMqConnection.CreateModel())
    {

        rabbitMqChannel.QueueDeclare(queue: queueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        rabbitMqChannel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        int messageCount = Convert.ToInt16(rabbitMqChannel.MessageCount(queueName));
        Console.WriteLine(" Listening to the queue. This channels has {0} messages on the queue", messageCount);

        var consumer = new EventingBasicConsumer(rabbitMqChannel);
            consumer.Received += (model, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                Console.WriteLine(" Weather Forecast received: " + message);
                rabbitMqChannel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                Thread.Sleep(1000);
            };
            rabbitMqChannel.BasicConsume(queue: queueName,
                                 autoAck: false,
                                 consumer: consumer);
    }
}
Thread.Sleep(5000);