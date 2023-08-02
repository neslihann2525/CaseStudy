﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.RabbitMQConsumer.Providers
{
    public class RabbitMQSettings
    {
        public string? HostName { get; set; }
        public string? Port { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? QueueName { get; set; }
    }
}