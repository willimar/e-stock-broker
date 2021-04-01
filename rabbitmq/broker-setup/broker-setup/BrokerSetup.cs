using RabbitMQ.Client;
using RabbitMQ.Client.VHosts.Dto;
using RabbitMQ.RabbitMQ.Broker.Setup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.RabbitMQ.Broker.Setup
{
    internal sealed class BrokerSetup
    {
        private List<SetupModel> Setups { get; set; }

        public BrokerSetup()
        {
            this.Setups = new List<SetupModel>
            {
                ConfigureEmail(new SetupModel())
            };
        }

        #region Configurações de mensageria
        private SetupModel ConfigureEmail(SetupModel setup)
        {
            setup.VHost = new VHostDeclareDto() { Name = "E-Mail", Description = "Broker to balance the e-mail mesages.", Tags = "#e-mail #mesages" };
            setup.Exchanges = new List<ExchangeModel>() 
            {
                new ExchangeModel()
                { 
                    AutoDelete = false, 
                    Durable = true, 
                    Exchange = "E-mail to Send [Backlog]", 
                    Type = "direct", 
                    Arguments = null, 
                    Queues = new List<RabbitQueue>()
                    { 
                        new RabbitQueue() 
                        { 
                            Name = "E-Mail Flow Monitoring", 
                            AutoDelete = false, 
                            Durable = true, 
                            Exclusive = false, 
                            Arguments = null,
                            BindArguments = null,
                            RoutingKey = "a17ca8e2-ba93-4d19-8b73-c771bbbe958e"
                        },
                        new RabbitQueue()
                        {
                            Name = "E-mail Render",
                            AutoDelete = false,
                            Durable = true,
                            Exclusive = false,
                            Arguments = null,
                            BindArguments = null,
                            RoutingKey = "a17ca8e2-ba93-4d19-8b73-c771bbbe958e"
                        }
                    } 
                },
                new ExchangeModel()
                { 
                    AutoDelete = false, 
                    Durable = true, 
                    Exchange = "E-mail Renderized [Doing]", 
                    Type = "direct", 
                    Arguments = null,
                    Queues = new List<RabbitQueue>()
                    {
                        new RabbitQueue()
                        {
                            Name = "E-Mail Change Status",
                            AutoDelete = false,
                            Durable = true,
                            Exclusive = false,
                            Arguments = null,
                            BindArguments = null,
                            RoutingKey = "1e51341d-775c-4930-be45-720871926691"
                        },
                        new RabbitQueue()
                        {
                            Name = "E-mail Send",
                            AutoDelete = false,
                            Durable = true,
                            Exclusive = false,
                            Arguments = null,
                            BindArguments = null,
                            RoutingKey = "1e51341d-775c-4930-be45-720871926691"
                        }
                    }
                },
                new ExchangeModel()
                { 
                    AutoDelete = false, 
                    Durable = true, 
                    Exchange = "E-mail Tools [Factories]", 
                    Type = "direct", 
                    Arguments = null,
                    Queues = new List<RabbitQueue>()
                    {
                        new RabbitQueue()
                        {
                            Name = "E-mail Tools",
                            AutoDelete = false,
                            Durable = true,
                            Exclusive = false,
                            Arguments = null,
                            BindArguments = null,
                            RoutingKey = "872814ab-c827-466c-9067-8e1133005ce1"
                        }
                    }
                }
            };

            return setup;
        }
        #endregion

        public async Task Execute(ConnectionFactory hostFactory)
        {
            var hostList = await hostFactory.VHostList();

            foreach (var setup in this.Setups)
            {
                if (!hostList.Any(host => host.Name.ToLower().Equals(setup.VHost.Name.ToLower())))
                {
                    await hostFactory.VHostDeclare(setup.VHost);

                    var factory = new ConnectionFactory()
                    {
                        HostName = "localhost",
                        Password = "itsgallus",
                        Port = 5672,
                        UserName = "Admin",
                        VirtualHost = setup.VHost.Name
                    };

                    using var connection = factory.CreateConnection();
                    using var channel = connection.CreateModel();

                    foreach (var exchange in setup.Exchanges)
                    {
                        channel.ExchangeDeclare(exchange.Exchange, exchange.Type, exchange.Durable, exchange.AutoDelete, exchange.Arguments);
                        foreach (var queue in exchange.Queues)
                        {
                            channel.QueueDeclare(queue.Name, queue.Durable, queue.Exclusive, queue.AutoDelete, queue.Arguments);
                            channel.QueueBind(queue.Name, exchange.Exchange, queue.RoutingKey, queue.BindArguments);
                        }
                    }

                    channel.Close();
                    connection.Close();
                }
            }
        }
    }
}
