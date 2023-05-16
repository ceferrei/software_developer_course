using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Contract
{
    internal class Worker
    {
        /*Atributos da nossa classe worker*/

        /*As propriedades Name, Level e baseSalary são definidas como propriedades autoimplementadas 
        com get e set.Isso significa que podes ler e escrever o valor dessas propriedades fora da classe.*/

        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double baseSalary { get; set; }

        /*A propriedade Department é definida como uma propriedade autoimplementada com get e set, assim como 
         * as outras, mas ela é do tipo Department, que é outra classe que criamos e representa um departamento.*/

        public Department Department { get; set; }

        /*A propriedade Contracts é uma lista de contratos de horas (HourContract). No entanto, ela é inicializada 
         * com uma nova lista vazia no momento da criação de um objeto Worker. Isso é feito usando a sintaxe de 
         * inicialização de objeto ("= new List<HourContract>();"), que é uma maneira abreviada de criar um novo 
         * objeto List e atribuí-lo à propriedade Contracts.*/
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();


        /*Agora devemos criar métodos para adicionar e remover contratos, e um método para 
         * calcular o rendimento total do trabalhador em um determinado mês/ano.*/

        public void AddContract(HourContract contract)/*adiciona um novo contrato à lista de contratos do trabalhador*/
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)/*remove um contrato da lista de contratos do trabalhador*/
        {
            Contracts.Remove(contract);
        }
        public double Income(int month, int year)/* calcula o rendimento total do trabalhador num determinado mês/ano.*/
        {
            /*O método recebe como parâmetros um mês e um ano, e retorna um valor double que representa 
             * a soma do salário base do trabalhador mais o valor total dos contratos de trabalho realizados 
             * por ele no mês/ano especificado*/

            /*Para cada contrato, verificamos se o mês e o ano do contrato correspondem ao mês e ano especificados 
             * como parâmetro. Se a condição for verdadeira, adicionamos o valor total do contrato à variável soma.
             * Por fim, retornamos o valor da variável soma, que representa o rendimento total do trabalhador no mês/ano especificado.*/

            /*É importante destacar que a variável soma é inicializada com o valor do salário base do trabalhador, 
             * pois mesmo que não haja nenhum contrato realizado no mês/ano especificado, o trabalhador ainda tem 
             * direito a receber seu salário base.*/

            double soma = baseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (month == contract.Date.Month && year == contract.Date.Year)
                {
                    soma += contract.TotalValue();
                }
            }
            return soma;
        }
    }
}
