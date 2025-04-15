using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class Demo
    {
        StaffManage Manage = new();
        public void MainMenu()
        {

            bool loop = true;
            while (loop)
            {
                Console.WriteLine("***** Employee Managment System *****");
                Console.WriteLine("1-Department");
                Console.WriteLine("2-Staff Member");
                Console.WriteLine("3-Project");
                Console.WriteLine("99-Exit");

                Console.WriteLine("Enter Choice");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Manage.ManageDepartment();
                        break;
                    case 2:
                        Manage.ManageStaff();
                        break;
                    case 3:
                        Manage.ManagePro();
                        break;
                    case 99:
                        loop = false;
                        break;


                }
            }

        }
    }
}
