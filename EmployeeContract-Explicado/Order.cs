using System;

namespace Employee_Contract
{
    internal class Order
    {

        /*a classe Order precisa de um identificador (id) para identificar exclusivamente cada pedido, uma 
         * data e hora (datetime) para registrar quando o pedido foi feito e um status de pedido (OrderStatus)
         * para indicar o status atual do pedido, como "pendente", "em processo" ou "concluído".*/
        public int Id { get; set; }
        public DateTime Moment { get; set; }

        public OrderStatus Status { get; set; }

        /*public override string ToString()
        {
            return "\n"
                + "Id: " + Id
                + "\n"
                + "Moment: " + Moment
                + "\n"
                + "Status: " + Status;
        }*/
    }
}
