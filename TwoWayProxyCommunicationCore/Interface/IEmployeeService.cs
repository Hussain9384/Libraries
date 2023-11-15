using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWayProxyCommunication.Attributes;
using TwoWayProxyCommunication.Model;
using TwoWayProxyCommunication.Core.Models;

namespace TwoWayProxyCommunication.Core.Interface
{

    [ProxyService("EmployeeService")]
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        //AppResult<List<Employee>> GetEmployees();
    }
}
