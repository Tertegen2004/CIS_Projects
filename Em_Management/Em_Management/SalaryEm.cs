using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class SalaryEm : Employee
    {
        public double Salary { get; set; }
        public SalaryEm(int id,string name,string phone,string email,Department department,string ssn,double salary,string type)
            :base(name,id,phone,email,department,ssn,type)
        {
            Salary = salary;
        }

        public override double Pay()
        {
            return Salary;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Type => Employee Salary\nSalary:{Pay()}");
        }
    }
}
