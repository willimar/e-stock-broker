using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client.VHosts.Dto;

namespace RabbitMQ.Client.VHosts.Navigator
{
    [Headers("Authorization: Basic")]
    public interface IVHostDelete
    {
        [Delete("/api/vhosts/{hostDeleteDto.Name}")]
        Task VHostDelete([BodyAttribute] VHostDeleteDto hostDeleteDto);
    }
}
