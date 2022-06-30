using Microsoft.AspNetCore.Mvc;
using EmpApp_API.Interfaces;
using EmpApp_API.Model;
using Microsoft.AspNetCore.Hosting;


namespace EmpApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
 
        private readonly IEmployee _employeeManagementService;

        private readonly IWebHostEnvironment _env;
        public EmployeeController(IEmployee employeeManagementService, IWebHostEnvironment env)
        {
            _employeeManagementService = employeeManagementService;

            _env = env;
        }


        [HttpGet("getEmployeeDetail")]
        public IActionResult GetEmployeeDetail()
        {
            return (_employeeManagementService.GetEmployeeDetail());
        }




        [HttpPost("addEmployeeDetail")]
        public IActionResult AddEmployeeDetail(EmployeeModel employeeModel)
        {
            return (_employeeManagementService.AddEmployeeDetail(employeeModel));
        }

        [HttpPut("updateEmployeeDetail")]
        public IActionResult UpdateEmployeeDetail(EmployeeModel employeeModel)
        {
            return (_employeeManagementService.UpdateEmployeeDetail(employeeModel));
        }

        [HttpDelete("deleteEmployeeDetail={Id}")]
        public IActionResult DeleteEmployeeDetail(int Id)
        {
            return (_employeeManagementService.DeleteEmployeeDetail(Id));
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {

            return Ok("This is working");
        }
    }
}
