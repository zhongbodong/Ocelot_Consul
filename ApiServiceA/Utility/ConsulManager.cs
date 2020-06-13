using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServiceA.Utility
{
    public static class ConsulManager
    {
        public static void UseConsul( this IApplicationBuilder applicationBuilder,IConfiguration configuration, IConsulClient consul)
        {
            RegServer(configuration,consul);
        }
        private static void RegServer(IConfiguration configuration, IConsulClient consul)
        {
            string consulGroup = configuration["ConsulGroup"];

            string ip = configuration["ip"];

            int port = Convert.ToInt32(configuration["port"]);

            string serviceId = $"{consulGroup}_{ip}_{port}";

            var check = new AgentServiceCheck
            {
                Interval = TimeSpan.FromSeconds(6),
                HTTP = $"http://{ip}:{port}/heart",
                Timeout = TimeSpan.FromSeconds(2),
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(2)
            };

            var regist = new AgentServiceRegistration
            {
                Check = check,
                Address = ip,
                Port = port,
                Name = consulGroup,
                ID = serviceId
            };
            consul.Agent.ServiceRegister(regist);
        }

    }
}
