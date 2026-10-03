
using Part1_ProceduralToOOP;

namespace Part1_ProceduralToOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new();
            List<Product> products = new();
            List<Order> orders = new();

            int nextCustomerId = 1;
            int nextProductId = 1;
            int nextOrderId = 1;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== ORDER SYSTEM =====");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Show Customers");
                Console.WriteLine("4. Show Products");
                Console.WriteLine("5. Create Order");
                Console.WriteLine("6. Pay Order");
                Console.WriteLine("7. Sales Total");
                Console.WriteLine("8. Exit");

                Console.Write("Choose: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        break;

                    case "2":
                        AddProduct();
                        break;

                    case "3":
                        ShowCustomers();
                        break;

                    case "4":
                        ShowProducts();
                        break;

                    case "5":
                        CreateOrder();
                        break;

                    case "6":
                        PayOrder();
                        break;

                    case "7":
                        ShowSalesTotal();
                        break;

                    case "8":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            void AddCustomer()
            {
                Console.Write("Name: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Email: ");
                string email = Console.ReadLine() ?? "";

                Console.Write("City: ");
                string city = Console.ReadLine() ?? "";

                Console.Write("VIP? (y/n): ");
                bool isVip = Console.ReadLine()?.ToLower() == "y";

                Customer customer = new(
                    nextCustomerId++,
                    name,
                    email,
                    city,
                    isVip);

                customers.Add(customer);

                Console.WriteLine("Customer added successfully.");
            }

            void AddProduct()
            {
                Console.Write("Name: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Stock: ");
                int stock = int.Parse(Console.ReadLine() ?? "0");

                Product product = new Product(
                    nextProductId++,
                    name,
                    price,
                    stock
                    );

                products.Add(product);

                Console.WriteLine("Product added successfully.");
            }

            void ShowCustomers()
            {
                if (customers.Count == 0)
                {
                    Console.WriteLine("No customers.");
                    return;
                }

                foreach (Customer customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }

            void ShowProducts()
            {
                if (products.Count == 0)
                {
                    Console.WriteLine("No products.");
                    return;
                }

                foreach (Product product in products)
                {
                    Console.WriteLine(product);
                }
            }

            void CreateOrder()
            {
                if (customers.Count == 0 || products.Count == 0)
                {
                    Console.WriteLine(
                        "You need at least one customer and one product.");
                    return;
                }

                ShowCustomers();

                Console.Write("Customer ID: ");
                int customerId = int.Parse(Console.ReadLine() ?? "0");

                Customer? customer =
                    customers.FirstOrDefault(c => c.Id == customerId);

                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                Order order = new(
                    nextOrderId++,
                    customer,
                    DateTime.Now);

                while (true)
                {
                    ShowProducts();

                    Console.Write("Product ID (0 to finish): ");
                    int productId = int.Parse(Console.ReadLine() ?? "0");

                    if (productId == 0)
                        break;

                    Product? product =
                        products.FirstOrDefault(p => p.Id == productId);

                    if (product == null)
                    {
                        Console.WriteLine("Product not found.");
                        continue;
                    }

                    Console.Write("Quantity: ");
                    int quantity =
                        int.Parse(Console.ReadLine() ?? "0");

                    if (order.AddLine(product, quantity))
                    {
                        Console.WriteLine(
                            "Product added to order.");
                    }
                    else
                    {
                        Console.WriteLine(
                            "Could not add product.");
                    }
                }

                if (order.Lines.Count == 0)
                {
                    Console.WriteLine(
                        "Order was not created because it is empty.");
                    return;
                }

                orders.Add(order);

                Console.WriteLine(
                    $"Order #{order.Id} created.");

                Console.WriteLine(
                    $"Total: {order.CalculateTotal():F2}");
            }

            void PayOrder()
            {
                if (orders.Count == 0)
                {
                    Console.WriteLine("No orders.");
                    return;
                }

                Console.Write("Order ID: ");
                int orderId =
                    int.Parse(Console.ReadLine() ?? "0");

                Order? order =
                    orders.FirstOrDefault(o => o.Id == orderId);

                if (order == null)
                {
                    Console.WriteLine("Order not found.");
                    return;
                }

                if (order.MarkAsPaid())
                {
                    Console.WriteLine(
                        "Order paid successfully.");
                }
                else
                {
                    Console.WriteLine(
                        "Could not pay this order.");
                }
            }

            void ShowSalesTotal()
            {
                double total = orders
                    .Where(o => o.IsPaid)
                    .Sum(o => o.CalculateTotal());

                Console.WriteLine(
                    $"Total sales: {total:F2}");
            }
        }
    }
}

