using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class Budget
    {
        public int Id { get; set; }
        public double Value { get; set; }

        public Budget(int id,double value)
        {
            Id = id;
            Value = value;
        }

        public void IncreaseBudget(double more)
        {
            Value += more;
        }

        public void Print()
        {
            Console.WriteLine($"Buget Id:{Id} - Budget Value:{Value}");
        }
    }
}
