

using CaseStudy.RabbitMQConsumer;
using CaseStudy.RabbitMQConsumer.Providers;
using CaseStudy.RabbitMQConsumer.Providers.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development.json")
    .Build();

var emailServiceProvider = new ServiceCollection()
    .Configure<EmailSettings>(configuration.GetSection("EmailSettings"))
    .AddTransient<EmailService>()
    .BuildServiceProvider();

var rabbitMQSettings = configuration.GetSection("RabbitMQ").Get<RabbitMQSettings>();

var hostName = rabbitMQSettings!.HostName!;
var port = Convert.ToInt32(rabbitMQSettings!.Port);
var userName = rabbitMQSettings!.UserName!;
var password = rabbitMQSettings!.Password!;
var queueName = rabbitMQSettings!.QueueName!;

var factory = new ConnectionFactory();
factory.HostName = hostName;
factory.Port = port;
factory.UserName = userName;
factory.Password = password;
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

var emailConsumer = new RabbitMQEmailConsumer(hostName, port, userName, password, queueName, emailServiceProvider.GetRequiredService<EmailService>());
await emailConsumer.StartListening();

Console.WriteLine("mail yollandıktan sonra: " + emailConsumer.ToString());
Console.ReadKey();