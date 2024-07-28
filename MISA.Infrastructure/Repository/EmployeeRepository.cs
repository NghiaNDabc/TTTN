using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Misa.Core.Interfaces;
using Misa.Core.Entities;

namespace MISA.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepo
    {
        string connectionstring = "Host=localhost;Port=3306;Database=haui_2021605945_phamtrongnghia;User=ptnghia;Password=1";
        public int Delete(Employee obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Employee Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Employee obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
