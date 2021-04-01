using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.RabbitMQ.Broker.Setup.Model
{
    public class ExchangeModel
    {
        public string Exchange { get; set; }
        public string Type { get; set; }
        public bool Durable { get; set; }
        public bool AutoDelete { get; set; }
        public IDictionary<string, object> Arguments { get; set; }
        public List<RabbitQueue> Queues { get; set; }

        public ExchangeModel()
        {
            this.Arguments = new Dictionary<string, object>();
        }
    }
}
