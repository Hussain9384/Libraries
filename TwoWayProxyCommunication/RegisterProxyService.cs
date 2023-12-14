using Castle.Core.Configuration;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TwoWayProxyCommunication.Attributes;
using TwoWayProxyCommunication.Model;
using Microsoft.Extensions.Configuration;

namespace TwoWayProxyCommunication
{
    public static class RegisterProxyClients
    {
        public static void AddClientProxy(this IServiceCollection serviceCollection, IEnumerable<Type> types)
        {
            foreach (var item in types)
            {
                serviceCollection.AddTransient(item, s =>
                {
                    var client = s.GetService<HttpClient>();
                    var serviceConfigurations = s.GetService<List<ServiceConfiguration>>();
                    var config = s.GetService<Microsoft.Extensions.Configuration.IConfiguration>();
                    var serviceConfig = s.GetService<ServiceConfiguration>();

                    var attribute = item.GetCustomAttributes(typeof(ProxyService), true).FirstOrDefault() as ProxyService;


                    var proxyGenerator = new ProxyGenerator();
                    return proxyGenerator.CreateInterfaceProxyWithoutTarget(item, new ProxyInvoker(serviceConfig, client, attribute.serviceName));
                });
            }
        }
    }    
}
