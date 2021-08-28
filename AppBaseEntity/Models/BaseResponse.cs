using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBaseEntity.Models
{
   public class BaseResponse<T>
    {
        public T Result { get; set; }
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
