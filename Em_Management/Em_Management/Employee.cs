using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class Employee : StaffMember
    {
        public string SecurityNum { get; set; }
        

        public Employee(string name,int id,string phone,string email,Department department ,string ssn, string type)
            :base(id,name,phone,email,department,type)
        {
            SecurityNum = ssn;
        }

        public virtual void Print()
        {
            base.Print();
            Console.WriteLine($"Security Number:{SecurityNum}");
        }


    }
}
