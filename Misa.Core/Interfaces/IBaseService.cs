using Misa.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Core.Interfaces
{
    internal interface IBaseService< T> where T : class
    {
        ServiceResult InsertService( T obj );
        object ImportService( T obj );

    }
}
