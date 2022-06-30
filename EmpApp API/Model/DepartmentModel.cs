using System.Collections.Generic;

namespace EmpApp_API.Model
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class DepartmentDetails
    {
        public List<DepartmentModel> DepartmentDetail { get; set; }
    }
}
