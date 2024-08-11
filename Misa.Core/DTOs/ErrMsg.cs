using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Core.DTOs
{
    public class ErrMsg
    {
        public string devMsg { get; set; }
        public string userMsg { get; set; }
        public object data { get; set; }
    }
}
