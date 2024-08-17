using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.Core.Entities;
using Misa.Core.Interfaces;
using MySqlConnector;

namespace MISA_PTNghiaAPI.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        //Khai báo thông tin máy chú
        string connectionstring = "Host=localhost;Port=3306;Database=haui_2021605945_phamtrongnghia;User=root;Password=1";

        public DepartmentsController(IDepartmentRepo e)
        {
            this.departmentRepo = e;

        }
        IDepartmentRepo departmentRepo;

        [HttpGet]
        public IActionResult Get()
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                //lện sql
                var sql = "SELECT * FROM Department";

                //truy vấn
                var data = connection.Query<Department>(sql);

                // trả về dl
                return StatusCode(200, data);
            }
        }
        [HttpPost]
        public IActionResult Post(Department department)
        {

            //return
            var rs = departmentRepo.Insert(department);
            return 
            StatusCode(200, rs);
            
        }

        [HttpPut]
        public IActionResult Put([FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest("Không tìm thấy nhân viên.");
            }
            var rs = departmentRepo.Update(department);
            return StatusCode(200, rs);
            //tạo kết nối

        }
        [HttpDelete]
        public IActionResult Delete(Department d)
        {
            var result = departmentRepo.Delete(d);
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
