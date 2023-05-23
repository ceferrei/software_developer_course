using System.Globalization;

namespace Employee_Registration_and_Payments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of employees: ");
            int numberE = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for(int i = 1; i <= numberE; i++) 
            {
                Console.WriteLine($"Employee #{i} data: ");
                Console.Write("Outsourced (y/n): ");
                string yesOrNo = Console.ReadLine();
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value por hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());

                if(yesOrNo == "y" || yesOrNo == "Y")
                {
                    Console.Write("Additional charge: ");
                    double addCharge = double.Parse(Console.ReadLine());
                    employees.Add(new OutsourcedEmployee(addCharge, name, hours, valuePerHour));
                }
                else if(yesOrNo == "n" || yesOrNo== "N") 
                {
                    employees.Add(new Employee( name, hours, valuePerHour));
                }
                else
                {
                    Console.WriteLine("Error, the program will close.");
                    return;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("PAYMENTS: ");
            foreach(Employee employee in employees)
            {
                Console.WriteLine($"{employee.Name} - $ {employee.Payment().ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
    }
}