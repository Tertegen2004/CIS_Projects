using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public Department(int id,string name)
        {
            DepartmentID = id;
            DepartmentName = name;
        }
        public void Print()
        {
            Console.WriteLine($"Department Id:'{DepartmentID}'\nDepartment Name:'{DepartmentName}'");
        }

    }
}
