using System.Drawing;

namespace Car_EN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop s = new Shop();
            Console.WriteLine("Welcome to Car Store Program");
            Console.WriteLine("1-Add Car To Shop\n2-Add Car To Cart\n3-Check Out\n0-Exit");
            int action = choice();
            while (action != 0)
            {
                Console.WriteLine($"You Choice {action}");

                switch (action)
                {
                    case 1:
                        Console.WriteLine("Add Car");
                        string name = "";
                        string model = "";
                        string color = "";
                        int year = 0;
                        double price =0;

                        Console.WriteLine("Enter Car Name:");
                        name = Console.ReadLine();

                        Console.WriteLine("Enter Car Model:");
                        model = Console.ReadLine();

                        Console.WriteLine("Enter Car Color:");
                        color = Console.ReadLine();

                        year = exinput("Enter Year:");

                        price = exinput("Enter Car Price:");


                        Car c = new Car(name,model,color,year,price);

                        s.CarShop.Add(c);
                        Printshop(s);
                        break;

                    case 2:
                        Console.WriteLine("Welcom to You'r Cart");
                        Printshop(s);
                        int chose = exinput("Entr Num Of Car To Buy:");
                        try
                        {
                            s.Cart.Add(s.CarShop[chose]);
                        }
                        catch
                        {
                            Console.WriteLine("Shop is Empty");
                        }

                        Printcart(s);
                        break;

                    case 3:
                        Console.WriteLine("Car You Choose To Buy:");
                        Printcart(s);
                        Console.WriteLine($"The Total Cost Is:${s.Checkout()}");
                        break;

                }
                action = choice();
            }
        }

        static public int choice()
        {
            return exinput("Enter a Num");


        }

        static public int exinput(string message)
        {
            int ch;
            while (true)
            {
                try
                {
                    Console.WriteLine(message);

                    ch = int.Parse(Console.ReadLine());
                    return ch;
                }
                catch
                {
                    Console.WriteLine("Please Enter a Num");
                }
            }

        }

        static public void Printshop(Shop s)
        {
            Console.WriteLine("Car In The Shop Is:");

            for(int i = 0; i < s.CarShop.Count; i++)
            {
                Console.WriteLine($"Car #{i} {s.CarShop[i]}");
            }
        }

        static public void Printcart(Shop s)
        {
            Console.WriteLine("Car In The Cart Is:");

            for (int i = 0; i < s.Cart.Count; i++)
            {
                Console.WriteLine($"Car #{i} {s.Cart[i]}");
            }
        }
    }




    public class Car
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }


        public Car()
        {
            Name = "no thing";
            Model = "no thing";
            Color = "no thing";
            Year = 0;
            Price = 0;
        }

        public Car(string name,string model,string color,int year, double price)
        {
            Name = name;
            Model = model;
            Color = color;
            Year = year;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name:{Name} Model:{Model} Color:{Color} Year:{Year} Price:${Price}";
        }
    }

    public class Shop
    {
        public List<Car> CarShop { get; set; }
        public List<Car> Cart { get; set; }

        public Shop()
        {
            CarShop = new List<Car>();

            Cart = new List<Car>();
        }

        public double Checkout()
        {
            double tprice = 0;
            foreach (var item in Cart)
            {
                tprice += item.Price;
            }
            Cart.Clear();
            return tprice;
        }

    }


}
