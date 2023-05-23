using System;
using System.Globalization;

namespace Product_Price_Labels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            List<Product> list = new List<Product>();

            for (int i =1; i <= n; i++)
            {
                Console.WriteLine($"Product # {i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                string resp = Console.ReadLine();
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                if (resp == "c" || resp == "C")
                {
                    list.Add(new Product(name, price));
                }
                else if (resp == "u" || resp == "U")
                {
                    Console.Write("Manufacture date(DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(date, name, price));


                }
                else if (resp == "i" || resp == "I")
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new ImportedProduct(customsFee,  name, price));

                }
                else
                {
                    Console.WriteLine("Error, que pogram will end.");
                    return;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS: ");
            foreach (Product product in list)
            {
                // Console.WriteLine($"{ product.Name} - $ {product.Price}");
                Console.WriteLine($"{product.Name} $ {product.PriceTag()}");
            }
        }
    }
}