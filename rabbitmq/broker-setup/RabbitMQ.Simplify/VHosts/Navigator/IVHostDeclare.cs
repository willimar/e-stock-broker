using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client.VHosts.Dto;
using Refit;

namespace RabbitMQ.Client.VHosts.Navigator
{
    [Headers("Authorization: Basic")]
    public interface IVHostDeclare
    {
        [Put("/api/vhosts/{hostDeclare.Name}")]
        Task VHostDeclare([BodyAttribute] VHostDeclareDto hostDeclare);
    }
}
