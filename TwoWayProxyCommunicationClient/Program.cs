// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TwoWayProxyCommunication;
using TwoWayProxyCommunication.Attributes;
using TwoWayProxyCommunication.Core.Interface;
using TwoWayProxyCommunication.Model;

Console.WriteLine("Starting TwoWayProxyCommunicationClient");

var services = new ServiceCollection();

var assemblies = AppDomain.CurrentDomain.GetAssemblies();
//Assembly assembly = Assembly.GetExecutingAssembly(); // Change to your assembly name if needed

var types = assemblies
           .Where(assembly => assembly.FullName != null && assembly.FullName.Contains(".core", StringComparison.OrdinalIgnoreCase))
           .SelectMany(s => s.GetTypes()).Where(type => type.GetCustomAttributes(typeof(ProxyService), false).Any());


// Print the types with the attribute
foreach (var type in types)
{
    Console.WriteLine($"Type with ProxyService attribute: {type.Name}");
}

var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("Appsetting.json");

var configuration = builder.Build();

var serviceConfiguration = configuration.GetSection("ServiceConfiguration").Get<ServiceConfiguration>();

services.AddSingleton(serviceConfiguration);
services.AddHttpClient();
services.AddClientProxy(types);


var provider = services.BuildServiceProvider();

var employeeService = provider.GetRequiredService<IEmployeeService>();

var employees = employeeService.GetEmployees();

foreach (var employee in employees)
{
    Console.WriteLine(JsonConvert.SerializeObject(employee));
}