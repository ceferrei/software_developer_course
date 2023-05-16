using Employee_Contracts.Entities.Enum;
using System.Globalization;
using Employee_Contracts.Entities;

namespace Employee_Contracts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string nameDept = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Worker Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (1 - Junior, 2 - Mid_Level, 3 - Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department department = new Department(nameDept);
            Worker worker = new Worker(name, level, baseSalary, department);
            Console.WriteLine("How many contracts to this worker?");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"Enter #{i} contract data: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
                Console.WriteLine();
            }
            
            Console.WriteLine("Enter month and year to calculate income (MM/YYYY): ");
            string monthYear = Console.ReadLine();

            int month = int.Parse(monthYear.Substring(0,2));
            int year = int.Parse(monthYear.Substring(3));

            Console.WriteLine("Department name: " + department.NameDept);
            Console.WriteLine("Worker name: " + worker.Name);
            Console.WriteLine("Worker level: " + worker.Level);
            Console.WriteLine("Base salary: " + worker.BaseSalary.ToString("F2"));
            Console.WriteLine("Total income for: " + monthYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
