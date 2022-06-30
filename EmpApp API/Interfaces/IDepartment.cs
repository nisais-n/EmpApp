using EmpApp_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmpApp_API.Interfaces
{
    public interface IDepartment
    {
        JsonResult GetDepartmentDetail();
        JsonResult AddDepartmentDetail(DepartmentModel departmentModel);
        JsonResult UpdateDepartmentDetail(DepartmentModel departmentModel);

        JsonResult DeleteDepartmentDetail(int Id);
        JsonResult GetAllDepartmentNames();
    }
}
