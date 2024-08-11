using System;
using System.Collections.Generic;
using Misa.Core.Interfaces;
using Misa.Core.Entities;
using MySqlConnector;
using System.Data;

namespace MISA.Infrastructure.Repository
{
    public class DepartmentRepository : IBaseRepo<Department>
    {
        //khai báo connection string
        string connectionstring = "Host=localhost;Port=3306;Database=haui_2021605945_phamtrongnghia;User=ptnghia;Password=1";

        public int Delete(Department obj)
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                //lệnh sql
                var command = new MySqlCommand("DELETE FROM Department WHERE DepartmentID = @DepartmentID", connection);
                //truyền giá trị
                command.Parameters.AddWithValue("@DepartmentID", obj.DepartmentID);
                return command.ExecuteNonQuery();
            }
        }

        public int DeleteAll()
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                // xóa tất cả
                var command = new MySqlCommand("DELETE FROM Department", connection);
                return command.ExecuteNonQuery();
            }
        }

        public Department Get(Guid id)
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                //sql get
                var command = new MySqlCommand("SELECT * FROM Department WHERE DepartmentID = @DepartmentID", connection);
                //truyền giá trị
                command.Parameters.AddWithValue("@DepartmentID", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //trả về phòng ban
                        return new Department
                        {
                            DepartmentID = reader.GetGuid("DepartmentID"),
                            DepartmentName = reader.GetString("DepartmentName"),
                            CreatedDate = reader.GetDateTime("CreatedDate") ,
                            CreatedBy = reader.GetString("CreatedBy"),
                            ModifiedDate = reader.GetDateTime("ModifiedDate") ,
                            ModifiedBy = reader.GetString("ModifiedBy")
                        };
                    }
                }
            }
            return null;
        }

        public List<Department> GetAll()
        {
            var departments = new List<Department>();
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Department", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departments.Add(new Department
                        {
                            DepartmentID = reader.GetGuid("DepartmentID"),
                            DepartmentName = reader.GetString("DepartmentName"),
                            CreatedDate = reader.IsDBNull("CreatedDate") ? (DateTime?)null : reader.GetDateTime("CreatedDate"),
                            CreatedBy = reader.GetString("CreatedBy"),
                            ModifiedDate = reader.IsDBNull("ModifiedDate") ? (DateTime?)null : reader.GetDateTime("ModifiedDate"),
                            ModifiedBy = reader.GetString("ModifiedBy")
                        });
                    }
                }
            }
            return departments;
        }

        public int Insert(Department obj)
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                var command = new MySqlCommand(
                    "INSERT INTO Department (DepartmentID, DepartmentName, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy) " +
                    "VALUES (@DepartmentID, @DepartmentName, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy)",
                    connection);

                command.Parameters.AddWithValue("@DepartmentID", obj.DepartmentID);
                command.Parameters.AddWithValue("@DepartmentName", obj.DepartmentName);
                command.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate.HasValue ? obj.CreatedDate.Value : (object)DBNull.Value);
                command.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                command.Parameters.AddWithValue("@ModifiedDate", obj.ModifiedDate.HasValue ? obj.ModifiedDate.Value : (object)DBNull.Value);
                command.Parameters.AddWithValue("@ModifiedBy", obj.ModifiedBy);

                return command.ExecuteNonQuery();
            }
        }

        public int Update(Department obj)
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                //sql update
                var command = new MySqlCommand(
                    "UPDATE Department SET DepartmentName = @DepartmentName, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy, " +
                    "ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy WHERE DepartmentID = @DepartmentID",
                    connection);
                //truyền giá trị
                command.Parameters.AddWithValue("@DepartmentID", obj.DepartmentID);
                command.Parameters.AddWithValue("@DepartmentName", obj.DepartmentName);
                command.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate.HasValue ? obj.CreatedDate.Value : (object)DBNull.Value);
                command.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                command.Parameters.AddWithValue("@ModifiedDate", obj.ModifiedDate.HasValue ? obj.ModifiedDate.Value : (object)DBNull.Value);
                command.Parameters.AddWithValue("@ModifiedBy", obj.ModifiedBy);

                return command.ExecuteNonQuery();
            }
        }
    }
}
