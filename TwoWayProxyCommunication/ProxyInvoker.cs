using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWayProxyCommunication
{
    public class ProxyInvoker : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var employees = new List<string>
                {
                   "John" ,
                    "Alice",
                    "Bob" 
                };

                // Set the return value for List<Employee>
                invocation.ReturnValue = employees;
        }
    }
}
