using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manageer
{
    public class ContactViwer : IContactDB
    {
        public List<Contact> Contacts { get; set; } = new();

        public ContactViwer(List<Contact> contacts)
        {
            Contacts = contacts;
        }
        public void PrintAllContact()
        {
            if (Contacts.Any())
            {
                Console.WriteLine($"You Have ({Contacts.Count}) Contacts:\n");
                foreach (var item in Contacts)
                {
                    item.Print();
                }
            }
            else
            {
                Console.WriteLine("No Contacts !");
            }
            Console.WriteLine("Press...");
            Console.ReadKey();
        }
    }
}
