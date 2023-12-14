using Castle.DynamicProxy;
using Newtonsoft.Json;
using TwoWayProxyCommunication.Model;

namespace TwoWayProxyCommunication
{
    public class ProxyInvoker : IInterceptor
    {
        private readonly ServiceConfiguration _serviceConfigurations;
        private readonly string _serviceName;

        public ProxyInvoker(ServiceConfiguration serviceConfigurations, HttpClient httpClient, string serviceName)
        {
            _serviceConfigurations = serviceConfigurations;
            _httpClient = httpClient;
            _serviceName = serviceName;
        }

        public HttpClient _httpClient { get; }

        public async void Intercept(IInvocation invocation)
        {
            var serviceConfiguration = _serviceConfigurations.AppServiceConfigs.First(s => s.ServiceName == _serviceName);

            var uri = new Uri(serviceConfiguration.BaseUrl);

            _httpClient.BaseAddress = uri;

            HttpResponseMessage response = _httpClient.GetAsync("").GetAwaiter().GetResult();

            var content = await response.Content.ReadAsStringAsync();

            var returnType = invocation.Method.ReturnType;
            invocation.ReturnValue = JsonConvert.DeserializeObject(content, returnType);
        }
    }
}
