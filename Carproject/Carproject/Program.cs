using System.Linq;
using System.Collections;
namespace Carproject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ch;
            do
            {
                Console.WriteLine("**********Main Menu**********");
                Console.WriteLine("1-H(Menu)\n2-M(Menu)\n3-L(Menu)");
                Console.WriteLine("Enter Your Choice:");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        H h1 = new H();
                        h1.Screen();
                        break;
                    case 2:
                        M m1 = new M();
                        m1.Screen();
                        break;
                    case 3:
                        L l1 = new L();
                        l1.Screen();
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;

                }
            } while (ch <= 3);

        }
    }
    public interface Cars {

        public string Name { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }

        public void Add_Data();
        public void Show_Data();

    }

    public abstract class BaseCar : Cars
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string FileName { get; set; }

        public void Add_Data()
        {
            Console.Clear();
            Console.WriteLine("Enter Car Name:");
            Name = Console.ReadLine();

            Console.WriteLine("Enter Car Id:");
            Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Car Color:");
            Color = Console.ReadLine();

            Console.WriteLine("Enter Car Price:");
            Price = Convert.ToDouble(Console.ReadLine());

            File.AppendAllText(FileName, $"Name:{Name} Id:{Id} Price:{Price} Color:{Color}\n");
        }
        public void Show_Data()
        {
            if (File.Exists(FileName))
            {
                Console.WriteLine("Cars In Shop Is:");

                string[] lines = File.ReadAllLines(FileName);

                foreach (var line in lines)
                {
                    Console.WriteLine(line);

                }
            }
            else
            {
                Console.WriteLine("File Not Found..");
            }


        }
        public void Search_Id()
        {
            Console.WriteLine("Enter Id To Search:");
            string id = Console.ReadLine();

            string[] lines = File.ReadAllLines(FileName);
            bool found = false;

            foreach (var line in lines)
            {
                if (line.Contains($"Id:{id}"))
                {
                    Console.WriteLine($"Cars found:{line}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Car Not Found");
            }
        }
    }

    public class H : BaseCar 
    {
        public H()
        {
            FileName = "h.txt";
        }

        public void Screen()
        {
            Console.Clear();
            Console.WriteLine("***********Welcome To H Screen***********");
            Console.WriteLine("1-Add Cars\n2-Show Cars\n3-Search Car");

            Console.WriteLine("Enter Your Choice:");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Add_Data();
                    break;
                case 2:
                    Show_Data();
                    break;
                case 3:
                    Search_Id();
                    break;

            }
            Console.WriteLine("Enter Any Key To Back...");
            Console.ReadKey();
            Console.Clear();
        }

    }
    public class M : BaseCar
    {
        public M()
        {
            FileName = "m.txt";
        }
        public void Screen()
        {
            Console.Clear();
            Console.WriteLine("***********Welcome To M Screen***********");
            Console.WriteLine("1-Add Data\n2-Show Data\n3-Search Car");

            Console.WriteLine("Enter Your Choice:");
            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Add_Data();
                    break;
                case 2:
                    Show_Data();
                    break;
                case 3:
                    Search_Id();
                    break;

            }
            Console.WriteLine("Enter Any Key To Back...");
            Console.ReadKey();
            Console.Clear();
        }

    }
    public class L : BaseCar
    {
        public L()
        {
            FileName = "l.txt";
        }
        public void Screen()
        {
            Console.Clear();
            Console.WriteLine("***********Welcome To L Screen***********");
            Console.WriteLine("1-Add Data\n2-Show Data\n3-Search Car");

            Console.WriteLine("Enter Your Choice:");
            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Add_Data();
                    break;
                case 2:
                    Show_Data();
                    break;
                case 3:
                    Search_Id();
                    break;

            }
            Console.WriteLine("Enter Any Key To Back...");
            Console.ReadKey();
            Console.Clear();
        }


    }
    
}
