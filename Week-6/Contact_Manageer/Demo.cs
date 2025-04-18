using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manageer
{
    public class Demo
    {
        public void MainMenu()
        {
            List<Contact> Contacts = new();
            ContactManager manager = new(Contacts);
            ContactViwer contactViwer = new(Contacts);
            ContactUpdater contactUpdater = new(Contacts);
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("***** Welcome To Contact Management System *****");
                Console.WriteLine("1-Add Contact");
                Console.WriteLine("2-Remove Contact");
                Console.WriteLine("3-Update Contact");
                Console.WriteLine("4-Show Contacts");
                Console.WriteLine("99-Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:manager.AddContact();
                        break;
                    case 2:manager.DeleteContact();
                        break;
                    case 3:contactUpdater.UpdateContact();
                        break;
                    case 4:contactViwer.PrintAllContact();
                        break;
                    case 99:loop = false; break;
                    default: Console.WriteLine("Enter Valid Choice !"); Console.ReadKey();
                        break;
                }
            }

        }
    }
}
