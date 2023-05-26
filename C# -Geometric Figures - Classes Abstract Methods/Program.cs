using Geometric_Figures___Classes_Abstract_Methods.Entities;
using Geometric_Figures___Classes_Abstract_Methods.Entities.Enum;
using System.Globalization;

namespace Geometric_Figures___Classes_Abstract_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number os shapes: ");
            int number = int.Parse(Console.ReadLine());

            List<Shape> shapes = new List<Shape>();

            for(int i = 1; i <= number; i++)
            {
                Console.Write($"Shape #{i} data: ");
                Console.Write("Rectangle or circle (r/c)? ");
                string shape = Console.ReadLine();
                if( shape == "r" | shape == "R")
                {
                    Console.WriteLine("Color (Black/ Blue/ Red): ");
                    Color color = Enum.Parse<Color>(Console.ReadLine());
                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine());

                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine());

                    shapes.Add(new Rectangle(width, height, color));
                }
                else if( shape == "c" || shape == "C") 
                {
                    Console.Write("Color (Black/Blue/Red): ");
                    Color color = Enum.Parse<Color>(Console.ReadLine());

                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine());

                    shapes.Add(new Circle(radius, color));

                }
                else
                { 
                    Console.WriteLine("Wrong shape type!");
                    i--;
                }
                Console.WriteLine();
                Console.WriteLine("SHAPE AREAS:");

                foreach (Shape Shape in shapes)
                {
                    Console.WriteLine(Shape.Area().ToString("F2", CultureInfo.InvariantCulture));
                }
            }
        }
    }
}