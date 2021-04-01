using RabbitMQ.Client.VHosts.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.RabbitMQ.Broker.Setup.Model
{
    internal class SetupModel
    {
        public VHostDeclareDto VHost { get; set; }
        public List<ExchangeModel> Exchanges { get; set; }
    }
}
