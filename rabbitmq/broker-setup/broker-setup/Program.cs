using RabbitMQ.Client;
using RabbitMQ.Client.VHosts.Dto;
using RabbitMQ.RabbitMQ.Broker.Setup;
using System;
using System.Threading;

namespace RabbitMQ.Broker.Setup
{
    static class Program
    {
        private static ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory()
            {
                HostName = "localhost",
                Password = "itsgallus",
                Port = 5672,
                UserName = "Admin",
                VirtualHost = "e-stock-broker"
            };
        }

        private static void SetParameter(this ConnectionFactory connection)
        {
            connection.SetParameter(new Parameter()
            {
                Port = 15672,
                Password = "itsgallus",
                Url = @"localhost",
                UserName = "Admin",
                VHostName = "e-stock-broker",
                Protocol = Protocol.http
            });
        }

        static void Main(string[] args)
        {
            var factory = GetConnectionFactory();
            factory.SetParameter();
            
            var setup = new BrokerSetup();
            setup.Execute(factory).Wait();

            Console.WriteLine("Setup is done!");
            Console.ReadLine();
        }
    }
}
