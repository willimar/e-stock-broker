using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Client.VHosts.Dto
{
    [Serializable]
    public class VHostDeleteDto
    {
        public string Name { get; set; }
    }
}
