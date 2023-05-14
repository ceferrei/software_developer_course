using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Contract
{
    /*Esta classe representa o estado do pedido*/
    internal enum OrderStatus /*Substituimos class por enum*/
    {
        PendingPayment = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3
    }
}
