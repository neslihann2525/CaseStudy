using System;
using System.Text;
using CaseStudy.RabbitMQConsumer.Providers.Email;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CaseStudy.RabbitMQConsumer
{
    public class RabbitMQEmailConsumer
    {
        private readonly string _queueName;
        private readonly ConnectionFactory _connectionFactory;
        private readonly EmailService _emailService;

        public RabbitMQEmailConsumer(string hostName, int port, string userName, string password, string queueName, EmailService emailService)
        {
            _queueName = queueName;
            _connectionFactory = new ConnectionFactory
            {
                HostName = hostName,
                Port = port,
                UserName = userName,
                Password = password
            };

            _emailService = emailService; 
        }

        public async Task StartListening()
        {
            using (var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (sender, args) =>
                {
                    try
                    {
                        Console.WriteLine("consumer.Received is Running...");

                        var messageBody = Encoding.UTF8.GetString(args.Body.ToArray());
                        var emailMessage = JsonConvert.DeserializeObject<EmailMessage>(messageBody);

                        await _emailService.SendEmailAsync(emailMessage!.RecipientEmail!, emailMessage.Subject, emailMessage.Body);

                        channel.BasicAck(args.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error processing message: " + ex.Message);
                    }
                };

                channel.BasicQos(0, 1, false);

                channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);

                Console.WriteLine("Consumer started. Press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}