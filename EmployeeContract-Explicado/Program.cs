/*Read the data of a worker with N contracts (N provided by the user). Then, at the end, prompt the user to enter a month and show what 
the worker's income was for that month, as shown in the example.*/

using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Worker worker = new Worker();/*criamos o objeto apartir da classe (instanciacao), assim podemos ir buscar a classe e os metodos*/
        Console.WriteLine("Department name: ");
        string departmentName = Console.ReadLine();
        Department department = new Department(departmentName);/*enviamos a resposta do utilizador para a class e la usamos o construtor para guardar a info*/

        Console.WriteLine("Worker data: ");
        Console.WriteLine("Worker name: ");
        worker.Name = Console.ReadLine();

        Console.WriteLine("Worker level (1 - Junior, 2 - Mid_Level, 3 - Senior): ");
        worker.Level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
        /* esta linha faz a leitura da entrada do usuário e faz a conversao para o tipo WorkerLevel. O método Enum.Parse converte uma string num valor 
         * do tipo enum e, em seguida, é feita uma atribuição do valor convertido à propriedade Level do objeto worker*/

        Console.WriteLine("Base salary: ");
        worker.baseSalary = double.Parse(Console.ReadLine());

        Console.WriteLine("How many contracts does the worker have? ");
        int nContracts = int.Parse(Console.ReadLine());

        for (int i = 1; i <= nContracts; i++)
        {
            Console.WriteLine($"Contract #{i}: ");
            Console.WriteLine("Date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Value per hour: ");
            double valuePerHour = double.Parse(Console.ReadLine());
            Console.WriteLine("Duration (hours): ");
            int hours = int.Parse(Console.ReadLine());

            HourContract contract = new HourContract(date, valuePerHour, hours); /*enviamos as informacoes qpara serem usadas na classe*/
            worker.AddContract(contract);/*Adiciono o novo contrato atraves do metodo add*/
        }

        Console.WriteLine("\nEnter month and year to calculate income (MM/YYYY): ");
        string dateInput = Console.ReadLine();
        int month = int.Parse(dateInput.Substring(0, 2));
        int year = int.Parse(dateInput.Substring(3));
        double totalIncome = worker.Income(month, year);/*enviamos a info para a classe que vai calcular o rendimento total do trabalhador */

        Console.WriteLine("Department name: " + department.NameDep);
        Console.WriteLine("Worker name: " + worker.Name);
        Console.WriteLine("Worker level: " + worker.Level);
        Console.WriteLine("Base salary: " + worker.baseSalary.ToString("F2"));
        Console.WriteLine("Total income (salary + contracts): " + totalIncome.ToString("F2"));
    }

}
