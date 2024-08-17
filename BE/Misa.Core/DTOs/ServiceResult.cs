using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Core.DTOs
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
    }
}
