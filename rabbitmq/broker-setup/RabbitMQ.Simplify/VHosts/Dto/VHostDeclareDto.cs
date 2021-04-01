using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Client.VHosts.Dto
{
    [Serializable]
    public class VHostDeclareDto
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }
    }
}
