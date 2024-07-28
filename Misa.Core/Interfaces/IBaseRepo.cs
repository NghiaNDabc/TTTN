using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Core.Interfaces
{
    public interface IBaseRepo<T> where T :class
    {
         List<T> GetAll();
         T Get(Guid id);
        int Insert(T obj);
        int Update(T obj);
        int Delete(T obj);
        int DeleteAll();
    }
}
