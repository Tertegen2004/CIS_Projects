using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em_Management
{
    public class StaffManage
    {
        public List<StaffMember> StaffMembers;
        public List<Department> Departments;
        public List<Project> Projects;

        public StaffManage()
        {
            StaffMembers = new();
            Departments = new();
            Projects = new();
        } 

        public void ManageDepartment()
        {
            Console.Clear();

            Console.WriteLine("***** Department Management *****");
            Console.WriteLine("1-Add Department");
            Console.WriteLine("2-Show All Department");

            Console.WriteLine("Enter Choice:");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Department Id:");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Department Name:");
                    string name = Console.ReadLine();
                    Department department = new(id, name);
                    Departments.Add(department);

                    Console.WriteLine("Department Added Successfully");
                    Console.ReadKey();
                    break;
                case 2:
                    if (Departments.Any())
                    {
                        Console.WriteLine("Departments:");
                        foreach (var depart in Departments)
                        {
                            depart.Print();
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Departments !");
                    }
                    Console.ReadKey();
                    break;
                default: Console.WriteLine("Enter Valid Choice");
                    break;
            }

        }
        public void ManageStaff()
        {

            Console.Clear();

            Console.WriteLine("***** Staff Member Management *****");
            Console.WriteLine("1-Add Member");
            Console.WriteLine("2-Show All Member");
            Console.WriteLine("3-Calculate Payroll");
            Console.WriteLine("4-Delete Member");

            Console.WriteLine("Enter Choice:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Member Name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Employee Id:");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Member Phone:");
                    string phone = Console.ReadLine();

                    Console.WriteLine("Enter Member Email:");
                    string email = Console.ReadLine();

                    Console.WriteLine("Enter Member Type (Hourly/Salary/Volunteer/Comission/Excutive):");
                    string type = Console.ReadLine().ToUpper();

                    Console.WriteLine("Enter Member Department Id:");
                    int departid= int.Parse(Console.ReadLine());
                    var foundid = Departments.Find(i => i.DepartmentID == departid);
                    if (foundid != null)
                    {
                        switch (char.ToUpper(type[0]))
                        {
                            case 'S':
                                Console.WriteLine("Enter SSN:");
                                string sssn = Console.ReadLine();
                                Console.WriteLine("Enter Member Salary:");
                                double salary = double.Parse(Console.ReadLine());
                                SalaryEm salaryEm = new(id, name, phone, email, foundid, sssn, salary, type);
                                StaffMembers.Add(salaryEm);
                                break;
                            case 'V':
                                Console.WriteLine("Enter Member Amount:");
                                double amount = double.Parse(Console.ReadLine());
                                Volunteer volunteer = new(id, name, phone, email, foundid, amount, type);
                                StaffMembers.Add(volunteer);
                                break;
                            case 'C':
                                Console.WriteLine("Enter SSN:");
                                string cssn = Console.ReadLine();
                                Console.WriteLine("Enter Member Target:");
                                double target = double.Parse(Console.ReadLine());
                                ComissionEm cem = new(id,name,phone,email,foundid,cssn,target,type);
                                StaffMembers.Add(cem);
                                break;
                            case 'E':
                                Console.WriteLine("Enter SSN:");
                                string exssn = Console.ReadLine();

                                Console.WriteLine("Enter Member Bonus:");
                                double bonus = double.Parse(Console.ReadLine());

                                Console.WriteLine("Enter Member Salary:");
                                double exsalary = double.Parse(Console.ReadLine());
                                ExcutiveEm exem = new(id,name,phone,email,foundid,exssn,exsalary,bonus,type);
                                StaffMembers.Add(exem);
                                break;
                            case 'H':
                                Console.WriteLine("Enter SSN:");
                                string hssn = Console.ReadLine();

                                Console.WriteLine("Enter Member Rate:");
                                double rate = double.Parse(Console.ReadLine());

                                Console.WriteLine("Enter Member Hours Worke:");
                                double hour = double.Parse(Console.ReadLine());

                                HouarlyEm hem = new(id, name, phone, email, foundid,hssn,rate,hour, type);
                                StaffMembers.Add(hem);
                                break;
                            default:
                                Console.WriteLine("Wrong Type");
                                break;
                        }
                        Console.WriteLine("Member Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine($"Department With Id:'{departid}' Not Found");
                    }

                    Console.ReadKey();
                    break;
                case 2:
                    if (StaffMembers.Any())
                    {
                        Console.WriteLine("Members =>\n");
                        foreach (var member in StaffMembers)
                        {
                            member.Print();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Member");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Enter Id Of Member:");
                    int mtid = int.Parse(Console.ReadLine());
                    var m = StaffMembers.Find(id => id.Id == mtid);
                    if (m != null)
                    {
                        switch (char.ToUpper(m.Type[0]))
                        {
                            case 'S':
                                
                                Console.WriteLine($"Member Type Is:{m.Type} And Payroll:{m.Pay()}");
                                break;
                            case 'H':
                                Console.WriteLine($"Member Type Is:{m.Type} And Payroll:{m.Pay()}");
                                break;
                            case 'C':
                                Console.WriteLine($"Member Type Is:{m.Type} And Payroll:{m.Pay()}");
                                break;
                            case 'E':
                                Console.WriteLine($"Member Type Is:{m.Type} And Payroll:{m.Pay()}");
                                break;
                            case 'V':
                                Console.WriteLine($"Member Type Is:{m.Type} And Payroll:{m.Pay()}");
                                break;
                            default:
                                Console.WriteLine("UnKowon Type !");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Member Not Find");
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("Enter Id Of Member:");
                    int mid = int.Parse(Console.ReadLine());
                    var memberid = StaffMembers.Find(id => id.Id == mid);
                    if (memberid != null)
                    {
                        StaffMembers.Remove(memberid);
                        Console.WriteLine("Member Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Member Not Found");
                    }
                    Console.ReadKey();
                    break;
            }
        }
        public void ManagePro()
        {
            Console.Clear();
            Console.WriteLine("***** Project Manage *****");
            Console.WriteLine("1-Add Project");
            Console.WriteLine("2-Show All Projects");
            Console.WriteLine("3-Add Budget To Project");
            Console.WriteLine("4-Increase Budget To Existing Project");

            Console.WriteLine("Enter Choice:");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter Project Id:");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Project Location:");
                    string location = Console.ReadLine();

                    Console.WriteLine("Enter Current Cost:");
                    double current = double.Parse(Console.ReadLine());




                    Console.WriteLine("Enter Manager Id (Salary Member):");

                    int mid = int.Parse(Console.ReadLine());
                    var foundmanager = StaffMembers.Find(m => m.Id == mid);
                    if (foundmanager != null)
                    {
                        if(foundmanager is SalaryEm manager)
                        {
                            Console.WriteLine("Enter Project Budget Id:");
                            int pid = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Project Budget Value:");
                            double value = double.Parse(Console.ReadLine());

                            Project project = new(id, location, current, manager);

                            project.Budgets.Add(new(pid, value));
                            Projects.Add(project);

                            Console.WriteLine("Project Added Successfully");

                        }
                        else
                        {
                            Console.WriteLine($"Employee With Id:{mid} Cant be Manager !");
                        }
                     
                    }
                    else
                    {
                        Console.WriteLine($"Manager With Id:{mid} Not Found");
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    if (Projects.Any())
                    {
                        Console.WriteLine("Projects =>");
                        foreach (var project in Projects)
                        {
                            project.Print();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Projects");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Enter Project Id:");
                    int bid = int.Parse(Console.ReadLine());
                    var pro = Projects.Find(m => m.Id == bid);

                    if (pro != null)
                    {
                        Console.WriteLine("Enter Project Budget Id To Add:");
                        int pid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Budget Value To Add:");
                        double val = double.Parse(Console.ReadLine());
                        pro.IncreaseBudgets(new(pid,val));

                        Console.WriteLine("Budget Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Project Not Found");
                    }
                    Console.ReadKey();
                    
                    break;
                case 4:
                    Console.WriteLine("Enter Project Id:");
                    int proid = int.Parse(Console.ReadLine());

                    var proj = Projects.Find(m => m.Id == proid);

                    if (proj != null)
                    {
                        Console.WriteLine("Enter Budget Id");
                        int budid = int.Parse(Console.ReadLine());

                        var budget = proj.Budgets.Find(i => i.Id == budid);

                        if (budget != null)
                        {
                            Console.WriteLine("Enter Budget Value:");
                            double value = double.Parse(Console.ReadLine());
                            budget.IncreaseBudget(value);
                            Console.WriteLine("Budget Increase Successfully");
                        }
                        else
                        {
                            Console.WriteLine($"Budget With Id: {budid} Not Found");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Project Not Found");
                    }
                    Console.ReadKey();
                    break;
            }
        }
    }
}
