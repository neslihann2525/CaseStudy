using System;
using System.Net.Mail;
using System.Text;
using CaseStudy.Business.Providers.Email;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

public class RabbitMqSender
{
    private readonly string _queueName;
    private readonly ConnectionFactory _connectionFactory;

    public RabbitMqSender(string hostName, int port, string userName, string password, string queueName)
    {
        _queueName = queueName;
        _connectionFactory = new ConnectionFactory
        {
            HostName = hostName,
            Port = port,
            UserName = userName,
            Password = password
        };
        
    }

    public void SendEmailMessage(string recipientEmail, string subject, string body)
    {
        using (var connection = _connectionFactory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var messageBody = Encoding.UTF8.GetBytes(body);
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true; 

            var emailMessage = new EmailMessage
            {
                RecipientEmail = recipientEmail,
                Subject = subject,
                Body = body
            };

            var messageBodyBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(emailMessage));

            channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: properties, body: messageBodyBytes);
        }
    }
}
