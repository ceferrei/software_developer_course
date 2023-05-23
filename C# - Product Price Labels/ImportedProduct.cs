using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Price_Labels
{
    internal class ImportedProduct: Product
    {
        public double CustomsFee { get; set; }

        public ImportedProduct()
        {
            
        }

        public ImportedProduct(double customsFee, string name, double price)
            :base(name, price)
        {
            CustomsFee = customsFee;
        }

        public double TotalPrice()
        {
            return CustomsFee + Price;
        }
        public override string PriceTag()
        {
            return $"{TotalPrice()} (Customs Fee: ${CustomsFee.ToString("F2", CultureInfo.InvariantCulture)})";
        }


    }


}
