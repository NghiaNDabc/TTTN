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
        IBaseService<Employee> _baseService;
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
            
            //return
            var rs = _baseService.InsertService(employee);

            if (rs.IsSuccess = true) return StatusCode(200, rs);
            else return StatusCode(400, rs);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Không tìm thấy nhân viên.");
            }
            var rs = employeeRepo.Update(employee);
            return StatusCode(200, rs);
            //tạo kết nối
           
        }
        [HttpDelete]
        public IActionResult Delete(Employee e)
        {
            var result = employeeRepo.Delete(e);
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
