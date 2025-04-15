using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class ExcutiveEm : SalaryEm
    {
        double Bonus { get; set; }

        public ExcutiveEm(int id,string name,string phone,string email,Department department,string ssn,double salary,double bonus,string type)
            :base(id,name,phone,email,department,ssn,salary,type)
        {
            Bonus = bonus;
            Salary = salary;
        }

        public void AddBonus(double bonus)
        {
            Bonus += bonus;
        }

        public override double Pay()
        {
            return Salary += Bonus;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Type => Excutive Employee\nSalary:{Salary} - Bonus:{Bonus} - Payroll:{Pay()}");
        }
    }
}
