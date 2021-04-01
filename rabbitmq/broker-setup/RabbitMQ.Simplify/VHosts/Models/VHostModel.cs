using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Client.VHosts.Models
{
    public class VHostModel
    {
        [JsonProperty("cluster_state")]
        public dynamic ClusterState { get; set; }
        public string Description { get; set; }
        public VHostMetadataModel Metadata { get; set; }
        public string Name { get; set; }
        public List<string> Tags { get; set; }
        public bool Tracing { get; set; }
        [JsonProperty("recv_oct")]
        public int? RecvOct { get; set; }
        [JsonProperty("recv_oct_details")]
        public RecvOctDetailsModel RecvOctDetails { get; set; }
        [JsonProperty("send_oct")]
        public int? SendOct { get; set; }
        [JsonProperty("send_oct_details")]
        public SendOctDetailsModel SendOctDetails { get; set; }
    }
}
