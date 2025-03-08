namespace week1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu program = new();
            program.Mainmenu();
        }
    }


    public class Task
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Date { get; set; }
        public string Priority { get; set; }
        public string Progress { get; set; }

        public Task(string tit,string desc,string date,string prio,string prog)
        {
            Title = tit;
            Desc = desc;
            Date = date;
            Priority = prio;
            Progress = prog;
        }
    }

    public class TaskAction {

        public string Name { get; set; }

        public Task Task { get; set; }

        public TaskAction(string name,Task task)
        {
            Task = task;
            Name = name;
        }


    }

    public class TaskOperation {

        List<Task> ListOfTasks = new();
        Stack<TaskAction> TaskHistory = new();
        delegate void dlg(Task task, string update);

        void Updatetit(Task task, string value) => task.Title = value;
        void Updatedes(Task task, string value) => task.Desc = value;
        void Updateprio(Task task, string value) => task.Priority = value;
        void Updatedate(Task task, string value) => task.Date = value;
        void Updateprog(Task task, string value) => task.Progress = value;
        public void Add()
        {
            Console.WriteLine("Enter Task Title:");
            string t = Console.ReadLine();

            Console.WriteLine("Enter Task Descrption:");
            string d = Console.ReadLine();

            Console.WriteLine("Enter Task Due Date:");
            string date = Console.ReadLine();

            Console.WriteLine("Enter Task Priority (high/midum/low):");
            string pr = Console.ReadLine();

            Console.WriteLine("Enter Task Progress (in progress/pinding/completed):");
            string prog = Console.ReadLine();

            Task task = new(t, d, date, pr, prog);

            ListOfTasks.Add(task);
            var action = new TaskAction("Add", task);
            TaskHistory.Push(action);
            Console.WriteLine("Task Added Successfully");
            Console.WriteLine("press to back...");
            Console.ReadKey();
        }
        public void View()
        {
            Console.WriteLine("\nTask in List =>");

            if (ListOfTasks.Any())
            {
                foreach (var task in ListOfTasks)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"Ttitle:{task.Title}\nDescrption:{task.Desc}\nDue Date:{task.Date}\nPriority:{task.Priority}\nProgress:{task.Progress}");
                }

            }
            else
            {
                Console.WriteLine("No Task");
            }
            Console.WriteLine("press to back...");
            Console.ReadKey();

        }
        public void Remove()
        {
            if (ListOfTasks.Any())
            {
                View();
                Console.WriteLine("Enter Title Of Task");
                string tit = Console.ReadLine();

                var task = ListOfTasks.Find(t => t.Title == tit);
                if (task != null)
                {
                    ListOfTasks.Remove(task);
                    var action = new TaskAction("Remove", task);
                    TaskHistory.Push(action);
                    Console.WriteLine("Task Deleted");
                }
                else
                {
                    Console.WriteLine("Task Not Found");
                }
                Console.WriteLine("press to back...");
                Console.ReadKey();
            }

        }
        public void Update()
        {
            if (ListOfTasks.Any())
            {
                View();

                Console.WriteLine("Enter Title Of Task");
                string tit = Console.ReadLine();

                var task = ListOfTasks.Find(t => t.Title == tit);
                if (task != null)
                {
                    Console.WriteLine("1-Update Title");
                    Console.WriteLine("2-Update Desc");
                    Console.WriteLine("3-Update Date");
                    Console.WriteLine("4-Update Priority");
                    Console.WriteLine("5-Update Progress");

                    int ch = int.Parse(Console.ReadLine());
                    dlg dlg = null;
                    switch (ch)
                    {
                        case 1: dlg = Updatetit; break;
                        case 2: dlg = Updatedes; break;
                        case 3: dlg = Updatedate; break;
                        case 4: dlg = Updateprio; break;
                        case 5: dlg = Updateprog; break;
                    }

                    if (dlg != null)
                    {
                        Console.WriteLine("Enter New Value");
                        string newval = Console.ReadLine();

                        dlg(task, newval);
                        Console.WriteLine("Task Update Successfully");
                    }

                }
                else
                {
                    Console.WriteLine("Task Not Found");
                }

            }
            else
            {
                Console.WriteLine("No Tasks");
            }
            Console.WriteLine("press to back...");
            Console.ReadKey();


        }
        public void Undo()
        {
            if (TaskHistory.Count > 0)
            {
                var Lastaction = TaskHistory.Pop();
                if (Lastaction.Name == "Add")
                {
                    ListOfTasks.Remove(Lastaction.Task);
                    Console.WriteLine($"Undo : {Lastaction.Task.Title} Removed");
                }
                else if (Lastaction.Name == "Remove")
                {
                    ListOfTasks.Add(Lastaction.Task);
                    Console.WriteLine($"Undo : {Lastaction.Task.Title} Added");

                }
            }
            else
            {
                Console.WriteLine("No Operation To Undo");
            }

            Console.WriteLine("press to back...");
            Console.ReadKey();
        }

    }

    public class Menu
    {
        public void Mainmenu()
        {
            TaskOperation op = new();
            bool loop = true;

            while (loop)
            {
                Console.Clear();
                Console.WriteLine("**** Welcome Task Manager ****");
                Console.WriteLine("1-Add Task");
                Console.WriteLine("2-View Tasks");
                Console.WriteLine("3-Remove Task");
                Console.WriteLine("4-Undo Task");
                Console.WriteLine("5-Update Task");
                Console.WriteLine("6-Exit");
                int ch = 0;
                try
                {
                    Console.WriteLine("Enter You'r Choice");
                    ch = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wrong choice");
                    Console.ReadKey();
                };

                switch (ch)
                {
                    case 1:op.Add(); break;
                    case 2:op.View(); break;
                    case 3:op.Remove(); break;
                    case 4:op.Undo(); break;
                    case 5:op.Update(); break;
                    case 6:loop = false; break;
                    default: Console.WriteLine("Valid Choice");break;
                }
            }
        }
    }

}
