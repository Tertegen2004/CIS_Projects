namespace week4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationSystem SubUser = new();

            int choice = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("****** Welcome To Notification System ******");
                Console.WriteLine("\n1-Subscribe (Recive Notification)\n\n2-Unsubscribe (Don't Recive Notification)\n\n3-Send Notification\n\n4-Show Subscribers\n\n5-Exit\n");
                choice = ReciveChoice("Enter You'r Choice");
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("****** Subscribe Screen ******");
                        string name = "";
                        Console.WriteLine("Enter You'r Name : ");
                        name = Console.ReadLine();
                        var user = new User(name);
                        SubUser.SubUserList.Add(user);
                        SubUser.OnNotification += user.Recivenoti;
                        Console.WriteLine("Subscribe Successfully\npress any key to back...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("****** UnSubscribe Screen ******");
                        Console.WriteLine("Enter You'r Name : ");
                        name = Console.ReadLine();
                        var usr = SubUser.SubUserList.Find(t => t.Name == name);
                        if (usr != null)
                        {
                            SubUser.SubUserList.Remove(usr);
                            SubUser.OnNotification -= usr.Recivenoti;
                        }
                        else
                        {
                            Console.WriteLine("User Not Found");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("****** Send Notification Screen ******");
                        Console.WriteLine("Enter Message To Send");
                        string message = Console.ReadLine();
                        SubUser.SendNotification(message);
                        Console.WriteLine("Notification Sent Successfully\npress any key to back...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("****** Subscribe User Screen ******");
                        foreach (var person in SubUser.SubUserList)
                        {
                            Console.WriteLine($"User => {person.Name}");
                        }
                        Console.WriteLine("\npress any key to back...");
                        Console.ReadKey();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Choice..!\npress...");
                        Console.ReadKey();
                        break;
                }
            }


        }




        public static int ReciveChoice(string message)
        {
            Console.WriteLine(message);
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }


    public class User { 
        public string Name { get; set; }


        public User(string name)
        {
            Name = name;
        }


        public void Recivenoti(string message)
        {
            Console.WriteLine($"User {Name} Recived: {message}");
        }
    }


    public class NotificationSystem
    {
        public delegate void NotificationHandler(string message);
        public event NotificationHandler OnNotification;
        public List<User> SubUserList { get; set; }

        public NotificationSystem()
        {
            SubUserList = new();
        }

        public void SendNotification(string message)
        {

            OnNotification?.Invoke(message);

        }

    }
}
