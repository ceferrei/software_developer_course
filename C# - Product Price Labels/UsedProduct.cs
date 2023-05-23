using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Price_Labels
{
    internal class UsedProduct : Product
    {
        public DateTime ManufactureDate { get; set; }

        public UsedProduct()
        {
            
        }

        public UsedProduct(DateTime manufactureDate, string name, double price) 
            :base(name, price)
        {
            ManufactureDate = manufactureDate;
        }

        public override string PriceTag()
        {
            return $"{base.PriceTag()}  (used) $ (Manufacture date: {ManufactureDate.ToString("dd/MM/yyyy")})";
        }

    }
}
