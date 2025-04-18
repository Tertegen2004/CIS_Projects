using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manageer
{
    public class ContactManager : IContactDB
    {
        public List<Contact> Contacts { get; set; } = new();

        public ContactManager(List<Contact> contacts)
        {
            Contacts = contacts;
        }

        public void AddContact()
        {
            Console.Clear();
            Console.WriteLine("Enter Contact Name:");
            string name = Console.ReadLine();

            int phone = 0;
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter Contact Phone:");
                string p = Console.ReadLine();
                if(int.TryParse(p,out phone))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Enter Valid Number !");
                    Console.ReadKey();
                }

            }

            Console.WriteLine("Enter Contact Email:");
            string email = Console.ReadLine();

            Contacts.Add(new(name, phone, email));

            Console.WriteLine("Contact Added Successfully");
            Console.WriteLine("Press...");
            Console.ReadKey();
        }

        public void DeleteContact()
        {
            Console.Clear();
            if (Contacts.Any())
            {
                Console.WriteLine("Enter Contact Name:");
                string name = Console.ReadLine();

                var contact = Contacts.Find(c => c.Name == name);
                if (contact != null)
                {
                    Contacts.Remove(contact);
                    Console.WriteLine("Contact Deleted");
                }
                else
                {
                    Console.WriteLine("Contact Not Found !");
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
