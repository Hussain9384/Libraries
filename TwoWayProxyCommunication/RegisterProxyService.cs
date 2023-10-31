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
                    var proxyGenerator = new ProxyGenerator();
                    return proxyGenerator.CreateInterfaceProxyWithoutTarget(item, new ProxyInvoker());
                });
            }
        }
    }    
}
