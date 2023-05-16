using System;

namespace Employee_Contract
{
    /* Esta classe representa um contrato de trabalho por hora*/
    internal class HourContract /*internal significa que ela só pode ser acessida dentro do assembly em que foi definida.*/
    {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }


        /*Vamos declarar o construtor */
        public HourContract(DateTime date, double valuePerHour, int hours)
        {

            /*Vamos atribuir valores, que sao os que ele recebe do programa, ou seja que o utilizador escreveu no terminal*/
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        /*Criamos o metodo para calcular o valor total do contrato*/
        public double TotalValue()
        {
            return ValuePerHour * Hours;
            /*calcula o valor total do contrato com base no valor por hora e no número de horas trabalhadas. O resultado 
             * é o produto do valor por hora e do número de horas trabalhadas, ou seja, o valor total pago ao trabalhador 
             * pelo contrato de trabalho.*/
        }
    }
}
