using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_and_Display_Order_Summary
{
    internal class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double PriceOrder { get; set; }
        public OrderItem() { }

        public OrderItem(Product product, int quantity, double priceOrder)
        {
            Product = product;
            Quantity = quantity;
            PriceOrder = priceOrder;
        }

        public double SubTotal()
        {
            return Quantity * PriceOrder;
        }
        public override string ToString()
        {
            return Product.NameProduct + ", $" + PriceOrder.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantity: " + Quantity
                + ", Subtotal: $" + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }

}