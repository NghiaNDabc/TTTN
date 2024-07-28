using Misa.Core.DTOs;
using Misa.Core.Entities;
using Misa.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Core.Services
{
    public class EmployeeServices : IEmployeeService
    {
        IEmployeeRepo employeeRepo;
        public object ImportService(Employee obj)
        {
            throw new NotImplementedException();
        }

        public ServiceResult InsertService(Employee obj)
        {
            //var rs = employeeRepo.Insert(obj);
            //return ServiceResult.
            throw new NotImplementedException();
        }
    }
}
