using Read_and_Display_Order_Summary;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter client data: ");
        Console.Write("Name: ");
        string nameC = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Birth date (DD/MM/YYYY): ");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Enter order data: ");
        Console.Write("Status (Pending Paymnent/ Processing/ Shipped/ Delivered): ");
        OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
        Console.Write("How many items to this order? ");
        int n = int.Parse(Console.ReadLine());

        Client client = new Client(nameC, email, birthDate);
        Order order = new Order(new List<OrderItem>(), client, DateTime.Now);

        Console.WriteLine();
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter #{i} item data:");
            Console.Write("Product name: ");
            string nameP = Console.ReadLine();
            Console.Write("Product price: ");
            double priceP = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Product product = new Product(nameP, priceP);

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            OrderItem item = new OrderItem( product, quantity, priceP); // repara que enviamos o product
            order.addItem(item);
        }
        Console.WriteLine();
        Console.WriteLine("Order Summary: ");
        Console.WriteLine(order);
    }
}