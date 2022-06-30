using System.Collections.Generic;

namespace EmpApp_API.Model
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public decimal Salarary { get; set; }
        public string Department { get; set; }

    }

    public class EmployeeDetails
    {
        public List<EmployeeModel> EmployeeDetail { get; set; }
    }
}
