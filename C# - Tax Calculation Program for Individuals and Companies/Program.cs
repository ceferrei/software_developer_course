using Tax_Calculation_Program_for_Individuals_and_Companies.Entities;

namespace Tax_Calculation_Program_for_Individuals_and_Companies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxPayers = new List<TaxPayer>();
            Console.Write("Enter the number of tax payers: ");
            int number = int.Parse(Console.ReadLine());
            for(int i = 0; i < number; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");
                Console.Write("Individual or company (i / c) ? ");
                string ans = Console.ReadLine();
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine());
                
                if (ans == "i" || ans == "I")
                {
                    Console.Write("Health expenditures: ");
                    double healthExp = double.Parse(Console.ReadLine());
                    Individual individual = new Individual(healthExp, name, anualIncome);
                    taxPayers.Add(individual);
                }
                else if (ans == "c" || ans == "C") 
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    Company company = new Company(numberOfEmployees, name, anualIncome);
                    taxPayers.Add(company);
                }
            }
            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");

            double totalTax = 0;

            foreach (TaxPayer taxPayer in taxPayers)
            {
                double tax = taxPayer.Tax();
                totalTax += tax;

                Console.WriteLine(taxPayer.Name + ": $" + tax.ToString("F2"));
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $" + totalTax.ToString("F2"));
        }
    }
}