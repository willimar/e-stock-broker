using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Client
{
    public enum Protocol
    {
        http = 1,
        https = 2
    }

    public class Parameter
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Url { get; set; }
        public string VHostName { get; set; }
        public Protocol Protocol { get; set; }
    }

    public static class ParameterBase
    {
        private static Parameter _parameter;

        public static void SetParameter(this ConnectionFactory connection, Parameter parameter)
        {
            ParameterBase._parameter = parameter;
        }

        public static Parameter GetParameter(this ConnectionFactory connection)
        {
            return ParameterBase._parameter;
        }
    }
}
