using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class Volunteer : StaffMember
    {
        public double Amount { get; set; }

        public Volunteer(int id,string name,string phone,string email,Department department,double amount,string type)
            :base(id,name,phone,email,department,type)
        {
            Amount = amount;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Volunteer Amount:{Amount}");
        }

        public override double Pay()
        {
            return Amount;
        }
    }
}
