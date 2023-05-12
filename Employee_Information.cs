using Employee_Information;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {


        List<Employee> employees = new List<Employee>();

        Console.WriteLine("Digite o múmero de funcionários: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter employee data {i}: ");
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string nome = Console.ReadLine();
            Console.Write("Salary: ");
            double saraly = double.Parse(Console.ReadLine());


            //Quero que a cada volta do loop seja adicionado o func à lista
            Employee emp = new Employee(id, nome, saraly);
            employees.Add(emp);
        }

        // Leitura do id do funcionário a ser aumentado
        Console.Write("Enter the id of the employee to be augmented: ");
        int idToAugm = int.Parse(Console.ReadLine());

        /*Vamos procurar o funcionáriopelo id. A variável e é usada para
         * representar cada elemento da lista em cada iteração do método Find*/
        Employee empToIncrease = employees.Find(e => e.Id == idToAugm);
        
        if (empToIncrease == null)
        {
            Console.WriteLine("No employee with the specified id was found. Operation aborted.");
            return;
        }

        // Leitura do percentual de aumento do salário
        Console.WriteLine("Enter the salary increase percentage: ");
        double percent = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        // Enviamos a percentagem para a função que está na classe com o argumento que possuio valor para %
        empToIncrease.IncreaseSalary(percent);

        // Mostra a listagem atualizada dos funcionários
        Console.WriteLine("Updated list of employees:");
        foreach (Employee emp in employees)
        {
            Console.WriteLine(emp);
        }
    }
}

namespace Employee_Information
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; private set; }



        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public void IncreaseSalary(double percentage)
        {
            Salary += Salary * percentage / 100;
        }
        public override string ToString()
        {
            return Id + ", "
                + Name + ", "
                + Salary.ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}
