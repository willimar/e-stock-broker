using System.Collections.Generic;

namespace RabbitMQ.Client.VHosts.Models
{
    public class VHostMetadataModel
    {
        public string Description { get; set; }
        public List<string> Tags { get; set; }
    }
}