using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    public class Department
    {
        public string DepartmentNumber { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentImageURL { get; set; }
        public Department(string departmentNumber, string departmentName, string departmentID)
        {
            this.DepartmentNumber = departmentNumber;
            this.DepartmentName = departmentName;
            this.DepartmentID = departmentID;
        }

        public Department()
        {

        }
    }
}
