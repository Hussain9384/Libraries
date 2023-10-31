using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWayProxyCommunication.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class ProxyService : Attribute
    {
        private readonly string _serviceName;

        public ProxyService(string serviceName)
        {
            _serviceName = serviceName;
        }
    }
}
