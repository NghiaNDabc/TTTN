using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Core.Exceptions
{
    public class ValidateException : Exception
    {
        string MessageValidate ;
        public ValidateException(string msg)
        {
            this.MessageValidate = msg;
        }

        public override string Message
        {
            get
            {
                return MessageValidate;
            }
        }
    }
}
