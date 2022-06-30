
using System.Data;
using System.Data.SqlClient;
using EmpApp_API.Interfaces;
using EmpApp_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EmpApp_API.DataServicesImplementations
{
    public class EmployeeServices :IEmployee
    {
        private readonly IConfiguration _configuration;

        public EmployeeServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JsonResult GetEmployeeDetail()
        {

            string query = @"
                                SELECT EmployeeId,FirstName,LastName,Email,convert(varchar(10),DateOfBirth,120) as DateOfBirth,
                                       Salary,Department
                                FROM dbo.Employee";

            DataTable employeeTable = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader employeeDetailReader;
            using (SqlConnection con = new SqlConnection(sqlDatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    employeeDetailReader = cmd.ExecuteReader();

                    employeeTable.Load(employeeDetailReader);
                    employeeDetailReader.Close();
                    con.Close();
                }
            }

            return new JsonResult(employeeTable);


        }


        public JsonResult AddEmployeeDetail(EmployeeModel employeeModel)
        {
            string query = @"
                                INSERT INTO dbo.Employee
                                VALUES (@FirstName,@LastName,@Email,@DateOfBirth,@Salary,@Department)";

            DataTable employeeTable = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader employeeDetailReader;
            using (SqlConnection con = new SqlConnection(sqlDatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {


                    cmd.Parameters.AddWithValue("@FirstName", employeeModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employeeModel.LastName);
                    cmd.Parameters.AddWithValue("@Email", employeeModel.Email);
                    cmd.Parameters.AddWithValue("@DateOfBirth", employeeModel.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salarary);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);

                    employeeDetailReader = cmd.ExecuteReader();
                    employeeTable.Load(employeeDetailReader);
                    employeeDetailReader.Close();
                    con.Close();
                }
            }

            return new JsonResult("ADDED SUCCESSFULLY");
        }

        public JsonResult UpdateEmployeeDetail(EmployeeModel employeeModel)
        {
            string query = @"
                                UPDATE  dbo.Employee SET
                                FirstName = @FirstName,
                                LastName = @LastName,
                                Email = @Email,
                                DateOfBirth = @DateOfBirth,
                                Salary = @Salary,
                                Department = @Department
                                WHERE EmployeeId = @EmployeeId";

            DataTable employeeTable = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader employeeDetailReader;
            using (SqlConnection con = new SqlConnection(sqlDatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@FirstName", employeeModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employeeModel.LastName);
                    cmd.Parameters.AddWithValue("@Email", employeeModel.Email);
                    cmd.Parameters.AddWithValue("@DateOfBirth", employeeModel.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salarary);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);

                    employeeDetailReader = cmd.ExecuteReader();
                    employeeTable.Load(employeeDetailReader);
                    employeeDetailReader.Close();
                    con.Close();
                }
            }

            return new JsonResult("UPDATED SUCCESSFULLY");
        }

        public JsonResult DeleteEmployeeDetail(int Id)
        {
            string query = @"
                                DELETE FROM  dbo.Employee 
                                WHERE EmployeeId = @EmployeeId";

            DataTable EmployeeTable = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader EmployeeDetailReader;
            using (SqlConnection con = new SqlConnection(sqlDatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {


                    cmd.Parameters.AddWithValue("@EmployeeId", Id);
                    EmployeeDetailReader = cmd.ExecuteReader();
                    EmployeeTable.Load(EmployeeDetailReader);
                    EmployeeDetailReader.Close();
                    con.Close();
                }
            }

            return new JsonResult("DELETED SUCCESSFULLY");
        }
    }
}
