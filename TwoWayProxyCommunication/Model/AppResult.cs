using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWayProxyCommunication.Model
{
    public class AppResult<T> where T : class
    {
        public T data { get; set; }

        public string status { get; set; }

        public string Message { get; set; }
    }
}
