using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCar.Services
{
    internal class PortugalTaxService: ITaxService
    {
        //Método
        public double Tax(double amount)
        {
            if (amount <= 100)
            {
                return amount * 0.20;
            }
            else
            {
                return (amount * 0.15);
            }
        }
    }
}
