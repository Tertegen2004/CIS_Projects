using System.Runtime.CompilerServices;
using static InventoryManagmentSystem.Invintory;

namespace InventoryManagmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu start = new();
            start.Menu();
        }


    }

    public class Product
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public double Price{ get; set; }
        public int Quantity{ get; set; }


        public Product(string name,string id,double price,int quanitiy)
        {
            Name = name;
            Price = price;
            Id = id;
            Quantity = quanitiy;
        }
    }

    public class Invintory
    {
        public List<Product> Products = new();
        public delegate void Mydlg(Product product,string value);
        
        void UpdateName(Product product, string value) => product.Name = value;
        void UpdateId(Product product, string value) => product.Id = value;
        void UpdatePrice(Product product, string value) => product.Price = Convert.ToDouble(value);
        void UpdateQuantity(Product product, string value) => product.Quantity = Convert.ToInt32(value);

        public void Add()
        {
            Console.WriteLine("Enter Product Id:");
            string id = Console.ReadLine();

            Console.WriteLine("Enter Product name:");
            string name = Console.ReadLine();

            double price = 0;
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter Product Price:");
                string p = Console.ReadLine();

                if(double.TryParse(p,out price))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid Price");
                }

            }
            isValid = false;
            int quantity = 0;
            while (!isValid)
            {
                Console.WriteLine("Enter Product Quantity:");
                string q = Console.ReadLine();

                if(int.TryParse(q,out quantity))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid Quantity");
                }
            }

            Product product = new(name, id, price, quantity);
            Products.Add(product);
            Console.WriteLine("Added Success");
            Console.WriteLine("Press..");
            Console.ReadKey();
        }

        public void Remove()
        {
            if (Products.Any())
            {
                View();
                Console.WriteLine("Enter Product Id:");
                string id = Console.ReadLine();

                var product = Products.Find(p => p.Id == id);
                if (product != null)
                {
                    Products.Remove(product);
                    Console.WriteLine("Product Deleted");
                }
                else
                {
                    Console.WriteLine("Product Not Found");
                }
            }
            else
            {
                Console.WriteLine("No Product Here");
            }

            Console.WriteLine("Press..");
            Console.ReadKey();

        }

        public void View()
        {
            if (Products.Any())
            {
                Console.WriteLine("Product In Invitory:\n");
                foreach (var product in Products)
                {
                    Console.WriteLine($"Name:{product.Name}");
                    Console.WriteLine($"Id:{product.Id}");
                    Console.WriteLine($"Price:{product.Price}");
                    Console.WriteLine($"Quantity:{product.Quantity}");
                    Console.WriteLine("------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Invintory Is Empty");
            }

            Console.WriteLine("Press...");
            Console.ReadKey();
        }

        public void Update()
        {
            if (Products.Any())
            {
                View();
                Console.WriteLine("Enter Id Of Product:");
                string id = Console.ReadLine();

                var product = Products.Find(p => p.Id == id);
                if (product != null)
                {
                    Console.WriteLine("1-Update Name");
                    Console.WriteLine("2-Update Price");
                    Console.WriteLine("3-Update Id");
                    Console.WriteLine("4-Update Quantity");

                    int ch = 0;
                    bool isValid = false;
                    while (!isValid)
                    {
                        Console.WriteLine("Enter Choice:");
                        string c = Console.ReadLine();

                        if (int.TryParse(c, out ch))
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice");
                        }
                        Mydlg dlg = null;
                        switch (ch)
                        {


                            case 1: dlg = UpdateName; break;
                            case 2: dlg = UpdatePrice; break;
                            case 3: dlg = UpdateId; break;
                            case 4: dlg = UpdateQuantity; break;


                        }
                        if (dlg != null)
                        {
                            Console.WriteLine("Enter New Value:");
                            string newVal = Console.ReadLine();

                            dlg(product, newVal);
                            Console.WriteLine("Product Updated Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Wrong Choice");
                        }

                    }


                }
                else
                {
                    Console.WriteLine("Product Not Found");
                }
            }
            else
            {
                Console.WriteLine("No Product");
            }
            Console.WriteLine("Press..");
            Console.ReadKey();
        }
    }

    public class MainMenu
    {
        Invintory invintory = new();
        public void Menu()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("**** Welcome Invintory Managment System ****");
                Console.WriteLine("1-Add Product");
                Console.WriteLine("2-Remove Product");
                Console.WriteLine("3-Update Product");
                Console.WriteLine("4-View Product");
                Console.WriteLine("5-Exit");

                Console.WriteLine("\nEnter Choice:");
                int ch = 0;
                
                try
                {
                    ch = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Some Thing Is Wrong {ex.Message}");
                    Console.ReadKey();
                }

                switch (ch)
                {
                    case 1:invintory.Add(); break;
                    case 2:invintory.Remove(); break;
                    case 3:invintory.Update(); break;
                    case 4:invintory.View(); break;
                    case 5:loop=false; break;
                    default: Console.WriteLine("Wrong Choice");break;
                }
            }

        }
    }
}
