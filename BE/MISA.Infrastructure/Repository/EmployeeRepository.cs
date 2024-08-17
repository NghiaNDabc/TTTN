using System;
using System.Collections.Generic;
using System.Data;
using Misa.Core.Interfaces;
using Misa.Core.Entities;
using MySqlConnector;

namespace MISA.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepo
    {
        //khai báo connection string
        string connectionstring = "Host=localhost;Port=3306;Database=haui_2021605945_phamtrongnghia;User=ptnghia;Password=1";

        public int Delete(Employee obj)
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
            //sql
                var command = new MySqlCommand("DELETE FROM Employee WHERE EmployeeId = @EmployeeId", connection);
                command.Parameters.AddWithValue("@EmployeeId", obj.EmployeeId);
                return command.ExecuteNonQuery();
            }
        }

        public int DeleteAll()
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM Employee", connection);
                return command.ExecuteNonQuery();
            }
        }

        public Employee Get(Guid id)
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Employee WHERE EmployeeId = @EmployeeId", connection);
                command.Parameters.AddWithValue("@EmployeeId", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Employee
                        {
                            EmployeeId = reader.GetGuid("EmployeeId"),
                            FullName = reader.GetString("FullName"),
                            DateOfBirth = reader.IsDBNull("DateOfBirth") ? (DateTime?)null : reader.GetDateTime("DateOfBirth"),
                            Gender = reader.IsDBNull("Gender") ? (bool?)null : reader.GetBoolean("Gender"),
                            PhoneNumber = reader.GetString("PhoneNumber"),
                            Email = reader.GetString("Email"),
                            Address = reader.GetString("Address"),
                            IdentityNumber = reader.GetString("IdentityNumber"),
                            IdentityDate = reader.GetString("IdentityDate"),
                            IdentityPlace = reader.GetString("IdentityPlace"),
                            CreatedDate = reader.IsDBNull("CreatedDate") ? (DateTime?)null : reader.GetDateTime("CreatedDate"),
                            CreatedBy = reader.GetString("CreatedBy"),
                            ModifiedDate = reader.IsDBNull("ModifiedDate") ? (DateTime?)null : reader.GetDateTime("ModifiedDate"),
                            ModifiedBy = reader.GetString("ModifiedBy"),
                            EmployeeCode = reader.GetString("EmployeeCode"),
                            DepartmentID = reader.GetGuid("DepartmentID")
                        };
                    }
                }
            }
            return null;
        }

        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Employee", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            EmployeeId = reader.GetGuid("EmployeeId"),
                            FullName = reader.GetString("FullName"),
                            DateOfBirth = reader.IsDBNull("DateOfBirth") ? (DateTime?)null : reader.GetDateTime("DateOfBirth"),
                            Gender = reader.IsDBNull("Gender") ? (bool?)null : reader.GetBoolean("Gender"),
                            PhoneNumber = reader.GetString("PhoneNumber"),
                            Email = reader.GetString("Email"),
                            Address = reader.GetString("Address"),
                            IdentityNumber = reader.GetString("IdentityNumber"),
                            IdentityDate = reader.GetString("IdentityDate"),
                            IdentityPlace = reader.GetString("IdentityPlace"),
                            CreatedDate = reader.IsDBNull("CreatedDate") ? (DateTime?)null : reader.GetDateTime("CreatedDate"),
                            CreatedBy = reader.GetString("CreatedBy"),
                            ModifiedDate = reader.IsDBNull("ModifiedDate") ? (DateTime?)null : reader.GetDateTime("ModifiedDate"),
                            ModifiedBy = reader.GetString("ModifiedBy"),
                            EmployeeCode = reader.GetString("EmployeeCode"),
                            DepartmentID = reader.GetGuid("DepartmentID")
                        });
                    }
                }
            }
            return employees;
        }

        public int Insert(Employee obj)
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                var command = new MySqlCommand(
                    "INSERT INTO Employee (EmployeeId, FullName, DateOfBirth, Gender, PhoneNumber, Email, Address, IdentityNumber, IdentityDate, IdentityPlace, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, EmployeeCode, DepartmentID) " +
                    "VALUES (@EmployeeId, @FullName, @DateOfBirth, @Gender, @PhoneNumber, @Email, @Address, @IdentityNumber, @IdentityDate, @IdentityPlace, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy, @EmployeeCode, @DepartmentID)",
                    connection);

                command.Parameters.AddWithValue("@EmployeeId", obj.EmployeeId);
                command.Parameters.AddWithValue("@FullName", obj.FullName);
                command.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth.HasValue ? obj.DateOfBirth.Value : (object)DBNull.Value);
                command.Parameters.AddWithValue("@Gender", obj.Gender.HasValue ? obj.Gender.Value : (object)DBNull.Value);
                command.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                command.Parameters.AddWithValue("@Email", obj.Email);
                command.Parameters.AddWithValue("@Address", obj.Address);
                command.Parameters.AddWithValue("@IdentityNumber", obj.IdentityNumber);
                command.Parameters.AddWithValue("@IdentityDate", obj.IdentityDate);
                command.Parameters.AddWithValue("@IdentityPlace", obj.IdentityPlace);
                command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                command.Parameters.AddWithValue("@CreatedBy","Admin");
                command.Parameters.AddWithValue("@ModifiedDate",DateTime.Now);
                command.Parameters.AddWithValue("@ModifiedBy", obj.ModifiedBy);
                command.Parameters.AddWithValue("@EmployeeCode", obj.EmployeeCode);
                command.Parameters.AddWithValue("@DepartmentID", obj.DepartmentID);

                return command.ExecuteNonQuery();
            }
        }

        public int Update(Employee obj)
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                connection.Open();
                var command = new MySqlCommand(
                    "UPDATE Employee SET FullName = @FullName, DateOfBirth = @DateOfBirth, Gender = @Gender, PhoneNumber = @PhoneNumber, Email = @Email, Address = @Address, IdentityNumber = @IdentityNumber, IdentityDate = @IdentityDate, IdentityPlace = @IdentityPlace, " +
                    "ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy, EmployeeCode = @EmployeeCode, DepartmentID = @DepartmentID WHERE EmployeeId = @EmployeeId",
                    connection);

                command.Parameters.AddWithValue("@EmployeeId", obj.EmployeeId);
                command.Parameters.AddWithValue("@FullName", obj.FullName);
                command.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth.HasValue ? obj.DateOfBirth.Value : (object)DBNull.Value);
                command.Parameters.AddWithValue("@Gender", obj.Gender.HasValue ? obj.Gender.Value : (object)DBNull.Value);
                command.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                command.Parameters.AddWithValue("@Email", obj.Email);
                command.Parameters.AddWithValue("@Address", obj.Address);
                command.Parameters.AddWithValue("@IdentityNumber", obj.IdentityNumber);
                command.Parameters.AddWithValue("@IdentityDate", obj.IdentityDate);
                command.Parameters.AddWithValue("@IdentityPlace", obj.IdentityPlace);
                command.Parameters.AddWithValue("@ModifiedDate",DateTime.Now);
                command.Parameters.AddWithValue("@ModifiedBy", "Admin");
                command.Parameters.AddWithValue("@EmployeeCode", obj.EmployeeCode);
                command.Parameters.AddWithValue("@DepartmentID", obj.DepartmentID);


                return command.ExecuteNonQuery();
            }
        }
    }
}
