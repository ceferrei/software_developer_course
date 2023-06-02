using System.Globalization;
using System.Xml.Schema;
using RentingCar.Entities;
using RentingCar.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter rental data");
        Console.Write("Car model:");
        string model = Console.ReadLine();
        Console.Write("Pickup (dd/MM/yyy hh:mm): ");
        DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
        Console.Write("Pickup (dd/MM/yyy hh:mm): ");
        DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
        Console.Write("Enter price per hour: ");
        double hour = double.Parse(Console.ReadLine());
        Console.Write("Enter price per day: ");
        double day = double.Parse(Console.ReadLine());


        CarRental carRental= new CarRental(start, finish, new Vehicle(model));

        RentalService rentalService = new RentalService(hour, day, new PortugalTaxService());

        rentalService.ProccesInvoice(carRental);
        Console.WriteLine("Invoice: ");
        Console.WriteLine();


    }
}