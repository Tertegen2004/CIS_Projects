namespace ShoppingSystem
{
    internal class Program
    {
        static Stack<string> undo_action = new Stack<string>();
        static public List<string> CartItems = new List<string>();
        static public Dictionary<string, double> avProducts = new Dictionary<string, double>()

        {
            {"Iphone",54000 },
            {"Laptop",32000 },
            {"TV",21000 },
        };
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("************ Welcome To Shopping System ************");
                Console.WriteLine("1-Add Items\n2-View Items\n3-Remove Items\n4-Check Out\n5-Undo Action\n6-Exit");
                Console.WriteLine("Enter You'r Choice:");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Add_item();
                        break;
                    case 2:
                        View_Cart();
                        break;
                    case 3:
                        Remove_item();
                        break;
                    case 4:
                        Check_Out();
                        break;
                    case 5:
                        Undo_Action();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;

                }
            }

        }

        public static void Add_item()
        {
            Console.Clear();
            Console.WriteLine("************ Welcome To Add Item Screen ************");
            Console.WriteLine("Product In Shop Is:");
            foreach (var item in avProducts)
            {
                Console.WriteLine($"Name:{item.Key} Price:{item.Value}");
            }

            Console.WriteLine("Enter Name Of Product To Add In You'r Cart:");
            string name = Console.ReadLine();
            if (avProducts.ContainsKey(name))
            {
                CartItems.Add(name);
                undo_action.Push($"Item {name} added");
                Console.WriteLine("Product Added Successfully\nEnter Any Key To Back...");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Product Not Found");
            }
        }

        public static void View_Cart()
        {
            Console.Clear();
            Console.WriteLine("Product in Cart Is:");
            var items = Getitemsprice();
            foreach (var item in items)
            {
                Console.WriteLine($"Name:{item.Item1} & Price:{item.Item2}");
            }
            Console.WriteLine("Enter Any Key To Back...");
            Console.ReadKey();
        }

        public static IEnumerable<Tuple<string, double>> Getitemsprice()
        {
            var CartPrice = new List<Tuple<string, double>>();

            foreach(var item in CartItems)
            {
                double price = 0;
                bool founditem = avProducts.TryGetValue(item, out price);

                if (founditem)
                {
                    Tuple<string, double> itemprice = new Tuple<string, double>(item, price);
                    CartPrice.Add(itemprice);
                }
            }
            return CartPrice;
        }

        public static void Remove_item()
        {
            Console.Clear();
            Console.WriteLine("********** Remove Product Screen **********");
            Console.WriteLine("Product in Cart Is:");
            var items = Getitemsprice();
            foreach (var item in items)
            {
                Console.WriteLine($"Name:{item.Item1} & Price:{item.Item2}");
            }
            Console.WriteLine("Enter The Name Of The Product To Delete:");
            string name = Console.ReadLine();

            for (int i = 0; i < CartItems.Count ;i++)
            {
                if (CartItems.Any())
                {
                    if (CartItems.Contains(name))
                    {
                        CartItems.Remove(name);
                        Console.WriteLine($"Product {name} Deleted Successfully");
                        undo_action.Push($"item {name} removed");
                        Console.WriteLine("Product Deleted Successfully\nEnter Any Key To Back...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Product Not Found");
                    }
                }
                else
                {
                    Console.WriteLine("Cart Is Empty");
                }
            }
        }

        public static void Check_Out()
        {
            Console.Clear();
            Console.WriteLine("********** Check Out Screen **********");
            double totalprice = 0;
            if (CartItems.Any())
            {
                var pincart = Getitemsprice();

                foreach (var item in pincart)
                {
                    totalprice += item.Item2;
                    Console.WriteLine($"Product => {item.Item1} & Price => {item.Item2}");
                }
                Console.WriteLine($"Total Price : {totalprice}");
                Console.WriteLine($"Payment Successfully");
                CartItems.Clear();
                undo_action.Push("Check Out");
            }
            else
            {
                Console.WriteLine("Cart Is Empty");
            }
            Console.WriteLine("Enter Any Key To Back...");
            Console.ReadKey();

        }

        public static void Undo_Action()
        {
            Console.Clear();
            Console.WriteLine("********** Undo Screen **********");
            if (undo_action.Any())
            {
                string lastaction = undo_action.Pop();
                Console.WriteLine($"Last Action Is : {lastaction}");
                var actionarr = lastaction.Split();

                if (actionarr.Contains("added"))
                {
                    CartItems.Remove(actionarr[1]);
                }
                else if (actionarr.Contains("removed"))
                {
                    CartItems.Add(actionarr[1]);
                }
                else
                {
                    Console.WriteLine("Check Out Cant't Undo");
                }
            }
            else
            {
                Console.WriteLine("No Action To Undo");
            }
            Console.WriteLine("Enter Any Key To Back...");
            Console.ReadKey();

        }
    }

}
