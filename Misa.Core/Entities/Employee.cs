using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Core.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string IdentityDate { get; set; }
        public string IdentityPlace { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string EmployeeCode { get; set; }
        public Guid DepartmentID { get; set; }
    }
}
