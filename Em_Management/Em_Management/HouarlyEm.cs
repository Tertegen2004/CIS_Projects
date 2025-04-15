using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class HouarlyEm : Employee
    {
        public double Rate { get; set; }

        public double HoursWorked { get; set; }

        public HouarlyEm(int id,string name,string phone,string email,Department department,string ssn,double rate,double hoursworked,string type)
            :base(name,id,phone,email,department,ssn,type)
        {
            Rate = rate;
            HoursWorked = hoursworked;
        }

        public override double Pay()
        {
            return Rate * HoursWorked;
        }

        public void AddHours(double more)
        {
            HoursWorked += more;
        }
        public override void Print()
        {
            Console.WriteLine($"Type => Houarly Employee\nRate:{Rate} - Hours Worked:{HoursWorked} - Payroll:{Pay()}");
        }
    }
}
