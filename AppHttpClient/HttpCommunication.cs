using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHttpClient
{
    internal class HttpCommunication 
    {
        private readonly HttpClient _httpClient;

        public HttpCommunication(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
