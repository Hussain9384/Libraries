using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWayProxyCommunication.Model
{
    public class AppServiceConfig
    {
        public string ServiceName { get; set; }
        public int RetryLimit { get; set; }
        public string BaseUrl { get; set; }
    }

    public class ServiceConfiguration
    {
        public List<AppServiceConfig> AppServiceConfigs { get; set; }
    }
}
