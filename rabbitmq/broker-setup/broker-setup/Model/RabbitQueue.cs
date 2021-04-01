using System.Collections.Generic;

namespace RabbitMQ.RabbitMQ.Broker.Setup.Model
{
    public class RabbitQueue
    {
        public string Name { get; internal set; }
        public bool Durable { get; internal set; }
        public bool Exclusive { get; internal set; }
        public bool AutoDelete { get; internal set; }
        public IDictionary<string, object> Arguments { get; internal set; }
        public string RoutingKey { get; internal set; }
        public IDictionary<string, object> BindArguments { get; internal set; }
    }
}