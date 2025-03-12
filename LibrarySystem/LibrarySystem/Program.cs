namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new();
            menu.Mainmenu();
        }
    }


    public class Menu
    {
        Library library = new();
        NotificationSystem notifi = new();
        User user ;
        Librarin librarin;

        public Menu()
        {
            user = new(library,notifi);
            librarin = new(library,notifi);
        }
        public void Mainmenu()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("***** Welcom To Library *****");
                Console.WriteLine("1-User");
                Console.WriteLine("2-Admin");
                Console.WriteLine("3-Exit");

                int ch = 0;
                bool Valid = false;
                while (!Valid)
                {
                    Console.WriteLine("Enter Choice:");
                    string choice = Console.ReadLine();
                    if(int.TryParse(choice,out ch))
                    {
                        Valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Choice");
                        Console.ReadKey();
                    }
                }

                switch (ch)
                {
                    case 1:user.Options();break;
                    case 2:librarin.Options();break;
                    case 3:loop = false; break;
                }
            }

        }
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author{ get; set; }
        public string Description{ get; set; }
        public string Id{ get; set; }
        public double Price{ get; set; }

        public Book(string t,string a,string d,string i,double p)
        {
            Title = t;
            Author = a;
            Description = d;
            Id = i;
            Price = p;
        }

    }
    public interface IlibraryCard
    {
        List<Book> BorrowedBooks { get; set; }

        public void BuyBook();
        public void ShowBookInCard();

    }
    public class User : IlibraryCard
    {
        public List<Book> BorrowedBooks { get; set; } = new();
        public List<string> Notification = new();

        Library library;
        NotificationSystem notisystem;

        public void BuyBook()
        {
            if (library.Books.Any())
            {
                library.ViewBooks();
      
                Console.WriteLine("Enter Book Id To Borrow:");
                string id = Console.ReadLine();

                var book = library.Books.Find(i => i.Id == id);
                if (book != null)
                {
                    BorrowedBooks.Add(book);
                    library.Books.Remove(book);
                    
                    Console.WriteLine("Borrowed Successfully");
                }
                else
                {
                    Console.WriteLine("Book Not Found");
                }
            }
            else
            {
                Console.WriteLine("Library is Empty");
            }
            Console.WriteLine("Press...");
            Console.ReadKey();

        }

        public void ShowBookInCard()
        {
            if (BorrowedBooks.Any())
            {
                Console.WriteLine("Borrowed Books:\n");
                foreach (var book in BorrowedBooks)
                {
                    Console.WriteLine($"Book Title:{book.Title}");
                    Console.WriteLine($"Book Id:{book.Id}");
                    Console.WriteLine($"Book Description:{book.Description}");
                    Console.WriteLine($"Book Author:{book.Author}");
                    Console.WriteLine($"Book Price:{book.Price}$");
                    Console.WriteLine("---------------------------");
                }
            }
            else
            {
                Console.WriteLine("No Borrowed Books");
            }
            Console.WriteLine("Press...");
            Console.ReadKey();
        }

        public void Options()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("***** Welcom User *****");
                Console.WriteLine("1-Borrow Book");
                Console.WriteLine("2-View Borrowed Books");
                Console.WriteLine("3-Show Notifications");
                Console.WriteLine("4-Back");

                int ch = 0;
                bool Valid = false;
                while (!Valid)
                {
                    Console.WriteLine("Enter Choice:");
                    string choice = Console.ReadLine();
                    if (int.TryParse(choice, out ch))
                    {
                        Valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Choice");
                        Console.ReadKey();
                    }
                }

                switch (ch)
                {
                    case 1: BuyBook();break;
                    case 2: ShowBookInCard();break;
                    case 3: ShowMessage(); break;
                    case 4: loop = false; break;
                }
            }
        }

        public void Recivenoti(string message)
        {
            string msg = ($"New Message: {message}");
            Notification.Add(msg);
        }

        public void ShowMessage()
        {
            Console.Clear();
            Console.WriteLine("***** Notifications *****");
            if (Notification.Any())
            {
                foreach(var noti in Notification)
                {
                    Console.WriteLine($"-{noti}");
                }
            }
            else
            {
                Console.WriteLine("No Notifications");
            }
            Console.WriteLine("Press...");
            Console.ReadKey();
        }

        public User(Library lib, NotificationSystem notifi)
        {
            library = lib;
            notisystem = notifi;
            notisystem.SendNoti += Recivenoti;
        }
    }
    public class Library
    {
        public List<Book> Books { get; set; }

        public void ViewBooks()
        {
            if (Books.Any())
            {
                Console.WriteLine("Books In Library:\n");
                foreach (var book in Books)
                {
                    Console.WriteLine($"Book Title:{book.Title}");
                    Console.WriteLine($"Book Id:{book.Id}");
                    Console.WriteLine($"Book Description:{book.Description}");
                    Console.WriteLine($"Book Author:{book.Author}");
                    Console.WriteLine($"Book Price:{book.Price}$");
                    Console.WriteLine("--------------------------");
                }
            }
            else
            {
                Console.WriteLine("Library Is Empty");
            }
            Console.WriteLine("Press...");
            Console.ReadKey();
        }
        public Library()
        {
            Books = new();
        }
    }
    public class Librarin
    {
        Library library;
        NotificationSystem notifications;
        public void AddBook()
        {
            string again = "";
            do
            {
                Console.WriteLine("Enter Book Id:");
                string id = Console.ReadLine();

                Console.WriteLine("Enter Book Title:");
                string title = Console.ReadLine();

                Console.WriteLine("Enter Book Author:");
                string author = Console.ReadLine();

                Console.WriteLine("Enter Book Descrotion:");
                string desc = Console.ReadLine();


                bool isvalid = false;
                double price = 0;
                while (!isvalid)
                {
                    Console.WriteLine("Enter Book Price:");
                    string p = Console.ReadLine();

                    if (double.TryParse(p, out price))
                    {
                        isvalid = true;
                    }
                    else
                    {
                        Console.WriteLine("Valid Price");
                    }
                }
                Book book = new(title, author, desc, id, price);
                
                library.Books.Add(book);
          
                Console.WriteLine("Book Added Successfully");
                Console.WriteLine("Do You Want Add Again:(y/n)");
                again = Console.ReadLine();
            } while (again.ToLower()=="y");

        }
        public void Remove()
        {
            if (library.Books.Any())
            {
                library.ViewBooks();
                Console.WriteLine("Enter Id:");
                string id = Console.ReadLine();

                var book = library.Books.Find(i => i.Id == id);
                if (book != null)
                {
                    library.Books.Remove(book);
                }
                else
                {
                    Console.WriteLine("Book Not Found");
                }
            }
            else
            {
                Console.WriteLine("Library is Empty");
            }
            Console.WriteLine("Press...");
            Console.ReadKey();

        }
        public void ViewBook()
        {
            library.ViewBooks();
        }
        public void Options()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("***** Welcom Admin *****");
                Console.WriteLine("1-Add Book");
                Console.WriteLine("2-View Book");
                Console.WriteLine("3-Remove Book");
                Console.WriteLine("4-Send Message");
                Console.WriteLine("5-Exit");

                int ch = 0;
                bool Valid = false;
                while (!Valid)
                {
                    Console.WriteLine("Enter Choice:");
                    string choice = Console.ReadLine();
                    if (int.TryParse(choice, out ch))
                    {
                        Valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Choice");
                        Console.ReadKey();
                    }
                }

                switch (ch)
                {
                    case 1: AddBook(); break;
                    case 2: library.ViewBooks(); break;
                    case 3: Remove(); break;
                    case 4: SendNotification(); break;
                    case 5: loop = false; break;

                }
            }
        }

        public void SendNotification()
        {
            Console.WriteLine("Enter Message To Send:");
            string msg = Console.ReadLine();
            notifications.Notifications(msg);
            Console.WriteLine("Message Send Successfully");
            Console.WriteLine("press...");
            Console.ReadKey();
        }

        public Librarin(Library lib, NotificationSystem notifi)
        {
            library = lib;
            notifications = notifi;
        }

    }

    public class NotificationSystem
    {
        public delegate void Dlg(string message);
        public event Dlg SendNoti;

        public void Notifications(string message)
        {
            SendNoti?.Invoke(message);
        }
    }
}
