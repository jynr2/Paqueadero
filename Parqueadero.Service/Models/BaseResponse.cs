using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parqueadero.Service.Models
{
    public class BaseResponse
    {
        public int OperationStatus { get; set; }
        public string Message { get; set; }
        public Object Entity { get; set; }
    }
}
