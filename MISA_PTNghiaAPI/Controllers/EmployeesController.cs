using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.Core.Entities;
using Misa.Core.Interfaces;
using MySqlConnector;

namespace MISA_PTNghiaAPI.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //Khai báo thông tin máy chú
        string connectionstring = "Host=localhost;Port=3306;Database=haui_2021605945_phamtrongnghia;User=root;Password=1";

        public EmployeesController(IEmployeeRepo e) {
            this.employeeRepo = e;

        }
        IEmployeeRepo employeeRepo;
        
        [HttpGet]
        public IActionResult Get()
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                //lện sql
                var sql = "SELECT * FROM Employee";

                //truy vấn
                var data = connection.Query<Employee>(sql);

                // trả về dl
                return StatusCode(200, data);
            }
        }
        [HttpPost]
        public IActionResult Post( Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
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
            //return
            return StatusCode(201, employee);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Không tìm thấy nhân viên.");
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
                return Ok(employee);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            //kết nói
            using var connection = new MySqlConnection(connectionstring);
            //lệnh sql
            var sql = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
            //thực hiện
            var result = connection.Execute(sql, new { EmployeeId = id });
            //trả về status code
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
