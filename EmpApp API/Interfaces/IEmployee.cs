using EmpApp_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmpApp_API.Interfaces
{
    public interface IEmployee
    {
        JsonResult GetEmployeeDetail();
        JsonResult AddEmployeeDetail(EmployeeModel employeeModel);
        JsonResult UpdateEmployeeDetail(EmployeeModel employeeModel);

        JsonResult DeleteEmployeeDetail(int Id);
    }
}
