
using System.Data;
using System.Data.SqlClient;
using EmpApp_API.Interfaces;
using EmpApp_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EmpApp_API.DataServicesImplementations
{
    public class DepartmentServices : IDepartment
    {
        private readonly IConfiguration _configuration;

        public DepartmentServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public JsonResult GetDepartmentDetail()
        {
           
                string query = @"
                                SELECT DepartmentId,DepartmentName
                                FROM dbo.Department";

                DataTable departmentTable = new DataTable();
                string sqlDatasource = _configuration.GetConnectionString("EmpAppCon");
                SqlDataReader departmentDetailReader;
                using(SqlConnection con = new SqlConnection(sqlDatasource))
                {
                    con.Open();
                    using(SqlCommand cmd = new SqlCommand(query, con))
                    {
                    departmentDetailReader = cmd.ExecuteReader();

                    departmentTable.Load(departmentDetailReader);
                    departmentDetailReader.Close();
                    con.Close(); 
                    }
                }

            return new JsonResult(departmentTable);

            
        }

        public JsonResult AddDepartmentDetail(DepartmentModel departmentModel)
        {
            string query = @"
                                INSERT INTO dbo.Department 
                                VALUES (@DepartmentName)";

            DataTable departmentTable = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader departmentDetailReader;
            using (SqlConnection con = new SqlConnection(sqlDatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    

                    cmd.Parameters.AddWithValue("@DepartmentName", departmentModel.DepartmentName);

                    departmentDetailReader = cmd.ExecuteReader();
                    departmentTable.Load(departmentDetailReader);
                    departmentDetailReader.Close();
                    con.Close();
                }
            }

            return new JsonResult("ADDED SUCCESSFULLY");
        }

        public JsonResult UpdateDepartmentDetail(DepartmentModel departmentModel)
        {
            string query = @"
                                UPDATE  dbo.Department SET
                                DepartmentName = @DepartmentName
                                WHERE DepartmentId = @DepartmentId";

            DataTable departmentTable = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader departmentDetailReader;
            using (SqlConnection con = new SqlConnection(sqlDatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {


                    cmd.Parameters.AddWithValue("@DepartmentName", departmentModel.DepartmentName);
                    cmd.Parameters.AddWithValue("@DepartmentId", departmentModel.DepartmentId);

                    departmentDetailReader = cmd.ExecuteReader();
                    departmentTable.Load(departmentDetailReader);
                    departmentDetailReader.Close();
                    con.Close();
                }
            }

            return new JsonResult("UPDATED SUCCESSFULLY");
        }

        public JsonResult DeleteDepartmentDetail(int  Id)
        {
            string query = @"
                                DELETE FROM  dbo.Department 
                                WHERE DepartmentId = @DepartmentId";

            DataTable departmentTable = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader departmentDetailReader;
            using (SqlConnection con = new SqlConnection(sqlDatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {


                    cmd.Parameters.AddWithValue("@DepartmentId", Id);
                    departmentDetailReader = cmd.ExecuteReader();
                    departmentTable.Load(departmentDetailReader);
                    departmentDetailReader.Close();
                    con.Close();
                }
            }

            return new JsonResult("DELETED SUCCESSFULLY");
        }

        public JsonResult GetAllDepartmentNames()
        {

            string query = @"
                                SELECT DepartmentName
                                FROM dbo.Department";

            DataTable departmentTable = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("EmpAppCon");
            SqlDataReader departmentDetailReader;
            using (SqlConnection con = new SqlConnection(sqlDatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    departmentDetailReader = cmd.ExecuteReader();

                    departmentTable.Load(departmentDetailReader);
                    departmentDetailReader.Close();
                    con.Close();
                }
            }

            return new JsonResult(departmentTable);


        }
    }
}

