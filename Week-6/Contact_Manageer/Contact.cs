using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manageer
{
    public class Contact
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }


        public Contact(string name,int phone,string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        public void Print()
        {
            Console.WriteLine($"Name:{Name} / Phone:{Phone} / Email:{Email}");
        }
    }
}
