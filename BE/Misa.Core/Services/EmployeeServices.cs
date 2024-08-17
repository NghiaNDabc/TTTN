using Misa.Core.DTOs;
using Misa.Core.Entities;
using Misa.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;

namespace Misa.Core.Services
{
    public class EmployeeServices : IEmployeeService
    {
        //Khai báo thông tin máy chú
        string connectionstring = "Host=localhost;Port=3306;Database=haui_2021605945_phamtrongnghia;User=root;Password=1";

        public object ImportService(Employee obj)
        {
            throw new NotImplementedException();
        }

        public ServiceResult InsertService(Employee employee)
        {
            if (employee == null)
            {
                return new ServiceResult { IsSuccess = false };
            }
            //tạo id mới
            employee.EmployeeId = Guid.NewGuid();
            //tạo ngày
            employee.CreatedDate = DateTime.Now;
            //gán người tọa
            employee.CreatedBy = "Admin";
            //gán ngày sửa
            employee.ModifiedDate = DateTime.Now;
            employee.ModifiedBy = "Admin";
            //lệnh sql insert
            
            using var connection = new MySqlConnection(connectionstring);
            var sql = @"
                INSERT INTO Employee (EmployeeId, FullName, DateOfBirth, Gender, PhoneNumber, Email, Address, IdentityNumber, IdentityDate, IdentityPlace, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, EmployeeCode, DepartmentID)
                VALUES (@EmployeeId, @FullName, @DateOfBirth, @Gender, @PhoneNumber, @Email, @Address, @IdentityNumber, @IdentityDate, @IdentityPlace, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy, @EmployeeCode, @DepartmentID)";
            var result = connection.Execute(sql, employee);
            return new ServiceResult { IsSuccess = true, Data = result };
        }
        public ServiceResult UpdateService(Employee employee)
        {
            if (employee == null)
            {
                return new ServiceResult {IsSuccess=false };
            }
            //tạo kết nối
            using var connection = new MySqlConnection(connectionstring);
            //lệnh sql
            var sql = @"
                UPDATE Employee 
                SET FullName = @FullName,
                    DateOfBirth = @DateOfBirth,
                    Gender = @Gender,
                    PhoneNumber = @PhoneNumber,
                    Email = @Email,
                    Address = @Address,
                    IdentityNumber = @IdentityNumber,
                    IdentityDate = @IdentityDate,
                    IdentityPlace = @IdentityPlace,
                    ModifiedDate = @ModifiedDate,
                    ModifiedBy = @ModifiedBy,
                    EmployeeCode = @EmployeeCode,
                    DepartmentID = @DepartmentID
                WHERE EmployeeId = @EmployeeId";

            //set các thông tin khác
            employee.ModifiedDate = DateTime.Now;
            employee.ModifiedBy = "Admin";
            //thực thi
            var result = connection.Execute(sql, employee);
            //trả về status code
            if (result > 0)
            {
                return new ServiceResult { IsSuccess = true, Data = result };
            }
            else
            {
                return new ServiceResult { IsSuccess = false };
            }
        }
    }
}
