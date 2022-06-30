using EmpApp_API.Interfaces;
using EmpApp_API.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EmpApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _departmentManagementService;
 
        public DepartmentController(IDepartment departmentManagementService)
        {
            _departmentManagementService = departmentManagementService;

        }


        [HttpGet("Test")]
        public IActionResult Test()
        {

            return Ok("This is working");
        }

        [HttpGet("getDepartmentDetail")]
        
        public JsonResult GetDepartmentDetail() 
        {
                return (_departmentManagementService.GetDepartmentDetail()); 
        }




        [HttpPost("addDepartmentDetail")]
        public IActionResult AddDepartmentDetail(DepartmentModel departmentModel)
        {
            return (_departmentManagementService.AddDepartmentDetail(departmentModel));
        }

        [HttpPut("updateDepartmentDetail")]
        public IActionResult UpdateDepartmentDetail(DepartmentModel departmentModel)
        {
            return (_departmentManagementService.UpdateDepartmentDetail(departmentModel));
        }

        [HttpDelete("deleteDepartmentDetail={Id}")]
        public IActionResult DeleteDepartmentDetail(int Id)
        {
            return (_departmentManagementService.DeleteDepartmentDetail(Id));
        }


        //Get All Employee Name for DropDown

        [HttpGet("getAllDepartmentName")]

        public IActionResult GetAllDepartmentNames()
        {
            return (_departmentManagementService.GetAllDepartmentNames());
        }
    }
}
