using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manageer
{
    public class ContactUpdater : IContactDB
    {
        public List<Contact> Contacts { get; set; } = new();

        delegate void mydlg(Contact contact, string value);
        void UpdateName(Contact contact, string value) => contact.Name = value;
        void UpdatePhone(Contact contact, string value) => contact.Phone = Convert.ToInt32(value);
        void UpdateEmail(Contact contact, string value) => contact.Email = value;

        public ContactUpdater(List<Contact>contacts)
        {
            Contacts = contacts;
        }
        public void UpdateContact()
        {
            if (Contacts.Any())
            {
                Console.Clear();
                Console.WriteLine("Enter Contact Name:");
                string name = Console.ReadLine();

                var contact = Contacts.Find(c => c.Name == name);

                if (contact != null)
                {
                    bool loop = true;
                    while (loop)
                    {
                        Console.Clear();
                        Console.WriteLine("1-Update Name");
                        Console.WriteLine("2-Update Phone");
                        Console.WriteLine("3-Update Email");
                        Console.WriteLine("99-Main Menu");

                        int choice = 0;
                        bool isValid = false;
                        while (!isValid)
                        {
                            Console.WriteLine("Enter Choice:");
                            string ch = Console.ReadLine();
                            if (int.TryParse(ch, out choice))
                            {
                                isValid = true;
                            }
                            else
                            {
                                Console.WriteLine("Enter Valid Number !");
                                Console.ReadKey();
                            }

                        }

                        mydlg dlg = null;

                        switch (choice)
                        {
                            case 1: dlg = UpdateName; break;
                            case 2: dlg = UpdatePhone; break;
                            case 3: dlg = UpdateEmail; break;
                            case 99: loop = false; break;
                            default:
                                Console.WriteLine("Enter Valid Choice !"); Console.ReadKey();
                                break;
                        }

                        if (dlg != null)
                        {
                            Console.WriteLine("Enter New Value:");
                            string newval = Console.ReadLine();
                            dlg(contact, newval);
                            Console.WriteLine("Contact Updated");
                            Console.WriteLine("Press...");
                            Console.ReadKey();
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Contact Not Found !");
                    Console.WriteLine("press...");
                    Console.ReadKey();
                }
            }

            else
            {
                Console.WriteLine("No Contacts !");
                Console.WriteLine("press...");
                Console.ReadKey();
            }
        }
    }
}
