using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace RabbitMQ.Client.VHosts.Navigator
{
    [Headers("Authorization: Basic")]
    internal interface IVHostList
    {
        [Get("/api/vhosts")]
        Task<string> GetHostListAssync();
    }
}
