using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Read_and_Display_Order_Summary
{
    internal class Order
    {
        public List <OrderItem> Items { get; set; } = new List <OrderItem> (); //dar o nome no plural
        public Client Client { get; set; }

        public DateTime Moment { get; set; }
        
        public OrderStatus Status { get; set; }



        //Construtores
        public Order() { }

        public Order(List<OrderItem> orderItem, Client client, DateTime moment) //Tirar a lista
        {
            Items = orderItem;
            Client = client;
            Moment = moment;
        }
        //Metodos
        public void addItem (OrderItem item) 
        { 
            Items.Add (item);
        }
        public void removeItem (OrderItem item)
        {
            Items.Remove (item);
        }
        public double Total () 
        {
            double sum = 0;
            foreach (OrderItem item in Items) 
            {
                sum += item.SubTotal(); //Vamos somar os sutotais da lista OrderItem
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items: ");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine (item.ToString());
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();

        }
    }
}
