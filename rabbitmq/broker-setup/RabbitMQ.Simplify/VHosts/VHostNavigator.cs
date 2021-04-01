using System;
using System.Collections.Generic;
using System.Text;
using Refit;
using System.Threading.Tasks;
using RabbitMQ.Client.VHosts.Models;
using RabbitMQ.Client.VHosts.Navigator;
using Newtonsoft.Json;
using RabbitMQ.Client.VHosts.Dto;
using Newtonsoft.Json.Serialization;

namespace RabbitMQ.Client
{
    public static class VHostNavigator
    {
        private static async Task<RefitSettings> GetRefitSettingsAsync(ConnectionFactory connection)
        {
            var parameter = connection.GetParameter();

            Func<Task<string>> getAuthHeader = () =>
            {
                return Task.FromResult(Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{parameter.UserName}:{parameter.Password}")));
            };

            new NewtonsoftJsonContentSerializer();

            var refitSettings = new RefitSettings()
            {
                AuthorizationHeaderValueGetter = () => getAuthHeader(),
                ContentSerializer = new NewtonsoftJsonContentSerializer
                (
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                )
            };

            return await Task.FromResult(refitSettings);
        }

        public static async Task<List<VHostModel>> VHostList(this ConnectionFactory connection)
        {
            var refitSettings = await GetRefitSettingsAsync(connection);
            var parameter = connection.GetParameter();

            var hostList = await GetRefitServiceAsync<IVHostList>($"{parameter.Protocol}://{parameter.Url}:{parameter.Port}", refitSettings);
            var json = await hostList.GetHostListAssync();

            return JsonConvert.DeserializeObject<List<VHostModel>>(json);
        }

        private static async Task<T> GetRefitServiceAsync<T>(string url, RefitSettings refitSettings)
        {
            var hostList = RestService.For<T>(url, refitSettings);
            return await Task.FromResult(hostList);
        }

        public static async Task VHostDeclare(this ConnectionFactory connection, VHostDeclareDto hostDeclare)
        {
            var refitSettings = await GetRefitSettingsAsync(connection);
            var parameter = connection.GetParameter();
            var hostList = await GetRefitServiceAsync<IVHostDeclare>($"{parameter.Protocol}://{parameter.Url}:{parameter.Port}", refitSettings);
            await hostList.VHostDeclare(hostDeclare);
        }

        public static async Task VHostDelete(this ConnectionFactory connection, VHostDeleteDto hostDelete)
        {
            var refitSettings = await GetRefitSettingsAsync(connection);
            var parameter = connection.GetParameter();
            var hostList = await GetRefitServiceAsync<IVHostDelete>($"{parameter.Protocol}://{parameter.Url}:{parameter.Port}", refitSettings);
            await hostList.VHostDelete(hostDelete);
        }
    }
}
