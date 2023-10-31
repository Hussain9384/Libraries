// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TwoWayProxyCommunication;
using TwoWayProxyCommunication.Attributes;
using TwoWayProxyCommunication.Core.Interface;

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


services.AddClientProxy(types);


var provider = services.BuildServiceProvider();

var employeeService = provider.GetRequiredService<IEmployeeService>();

var result = employeeService.GetEmployees();

foreach (var name in result)
{
    Console.WriteLine(name);
}