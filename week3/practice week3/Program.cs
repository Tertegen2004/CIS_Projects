namespace practice_week3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Program = new Menu();
            Program.MainMenu();
        }
    }


    public class Products
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }

        public Products(string name,int id,decimal price)
        {
            Name = name;
            Id = id;
            Price = price;

        } 
    }

    public class Cart
    {
        public List<Products> Products = new();
        public Stack<CartAction> Actionhistory = new();

        public decimal Tprice { get; set; }

        public void AddProduct()
        {
            Console.WriteLine("Enter Product Name:");
            string pname = Console.ReadLine();

            Console.WriteLine("Enter Product Id:");
            int pid = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product Price:");
            decimal pprice = decimal.Parse(Console.ReadLine());
            Tprice += pprice;
            var Product = new Products(pname, pid, pprice);
            Products.Add(Product);
            CartAction action = new CartAction("Add", Product);
            Actionhistory.Push(action);
            Console.WriteLine("Product Added Successfully");
            Console.WriteLine("Press To Back...");
            Console.ReadKey();
        }

        public void ShowTprice()
        {
            Console.WriteLine($"Total Price :{Tprice}");
            Console.WriteLine("\nPress To Back...");
            Console.ReadKey();
        }

        public void ViewCart()
        {
            int capacity = Products.Count;
            int count = 1;

            if (!Products.Any())
            {
                Console.WriteLine("Cart is Empty");
            }

            else
            {
                Console.WriteLine($"Cart Have {capacity} Product");
                Console.WriteLine("Product In Cart =>");
                foreach (var p in Products)
                {
                    Console.WriteLine($"({count})\nName : {p.Name}\nId : {p.Id}\nPrice : {p.Price}");
                    count++;
                }
            }
            Console.WriteLine("\nPress To Back...");
            Console.ReadKey();

        }

        public void RemoveProduct()
        {
            ViewCart();
            if (Products.Any())
            {
                Console.WriteLine("Enter ID Of Product:");
                int id = int.Parse(Console.ReadLine());

                var product = Products.Find(p => p.Id == id);

                if (product != null)
                {
                    Tprice -= product.Price;
                    Products.Remove(product);
                    Actionhistory.Push(new CartAction("Remove", product));
                    Console.WriteLine("Product Deleted Successfully");
                    Console.WriteLine("\nPress To Back...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Product Not Found");
                    Console.WriteLine("\nPress To Back...");
                    Console.ReadKey();
                }
            }

        }

        public void UndolastAction()
        {
            if (Actionhistory.Count > 0)
            {
                var lastaction = Actionhistory.Pop();

                if (lastaction.Action == "Add")
                {
                    Products.Remove(lastaction.Product);
                    Tprice -= lastaction.Product.Price;
                    Console.WriteLine($"Undo : Removed {lastaction.Product.Name}");
                    Console.WriteLine("\nPress To Back...");
                    Console.ReadKey();
                }
                else if (lastaction.Action == "Remove")
                {
                    Products.Add(lastaction.Product);
                    Tprice += lastaction.Product.Price;
                    Console.WriteLine($"Undo : Add {lastaction.Product.Name}");
                    Console.WriteLine("\nPress To Back...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No Action To Undo");
                Console.WriteLine("\nPress To Back...");
                Console.ReadKey();
            }
        }

        public void CheckOut()
        {
            ViewCart();
            ShowTprice();
            Console.WriteLine("Accept Pruches (y/n) ?");
            string ac = Console.ReadLine();
            if (ac == "y" || ac == "Y")
            {
                Console.WriteLine("Purches Successfully");
                Products.Clear();
                Actionhistory.Clear();
                Tprice = 0;
            }
            else
            {
                Console.WriteLine("Purches Not Complete");
            }
            Console.WriteLine("\nPress To Back...");
            Console.ReadKey();
        }
    }

    public class Menu
    {
        Cart Cart = new Cart();
        public void MainMenu()
        {
            bool loop = true;

            while (loop)
            {
                Console.Clear();
                Console.WriteLine("**** Main Menu ****");
                Console.WriteLine("1-Add Product To Cart");
                Console.WriteLine("2-View Product In Cart");
                Console.WriteLine("3-View Total Price");
                Console.WriteLine("4-Remove Product");
                Console.WriteLine("5-Undo Last Action");
                Console.WriteLine("6-Check Out");
                Console.WriteLine("7-Exist");
                Console.WriteLine("\nEnter Choice:");
                int ch = int.Parse(Console.ReadLine());
                
                switch (ch)
                {
                    case 1: Cart.AddProduct();break;
                    case 2: Cart.ViewCart();break;
                    case 3: Cart.ShowTprice();break;
                    case 4: Cart.RemoveProduct();break;
                    case 5: Cart.UndolastAction();break;
                    case 6: Cart.CheckOut();break;
                    case 7: loop=false; break;
                    default: Console.WriteLine("Invalid choice, try again."); break;
                }
            }
        }

        
    }

    public class CartAction
    {
        public string Action { get; set; }
        public Products Product { get; set; }

        public CartAction(string name, Products product)
        {
            Action = name;
            Product = product;
        }
    }
}
