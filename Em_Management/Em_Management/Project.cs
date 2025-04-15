using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class Project
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public double CurrentCost { get; set; }

        public Employee Manager { get; set; }

        public List<Budget> Budgets;

        public Project(int id,string location,double currentcost,Employee manager)
        {
            Id = id;
            Location = location;
            CurrentCost = currentcost;
            Manager = manager;
            Budgets = new();
        }

        public void IncreaseBudgets(Budget budget)
        {
            Budgets.Add(budget);
            CurrentCost += budget.Value;
        }

        public double TotalCost()
        {
            return Budgets.Sum(b => b.Value);
        }

        public void Print()
        {
            Console.WriteLine($"Project Id:{Id} - Project Location:{Location} - Manager:{Manager.Name} - Current Cost:{CurrentCost}");
            Console.WriteLine("Budgets:");
            foreach (var budget in Budgets)
            {
                budget.Print();
            }
        }

    }
}
