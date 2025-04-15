using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class ComissionEm : Employee
    {
        double Target { get; set; }

        public ComissionEm(int id,string name,string phone,string email,Department department,string ssn,double target,string type)
            :base(name,id,phone,email,department,ssn,type)
        {
            Target = target;
        }

        public override double Pay()
        {
            return .05 *Target;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Type => Excutive Employee\nTarget:{Target} - Payroll{Pay()}");

        }
    }
}
