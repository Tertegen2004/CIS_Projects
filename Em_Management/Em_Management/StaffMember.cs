using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class StaffMember
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }

        public Department Department { get; set; }

        public StaffMember(int id,string name,string phone,string email,Department department,string type)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Type = type;
            Department = department;
        }
        public virtual void Print()
        {
            Console.WriteLine($"Name:{Name} - Id:{Id} - Phone:{Phone} - Email:{Email} - Department:{Department.DepartmentName} - Type:{Type}");
        }

        public virtual double Pay()
        {
            return 0;
        }

    }
}
