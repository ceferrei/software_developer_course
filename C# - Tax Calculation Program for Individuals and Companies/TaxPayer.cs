using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Calculation_Program_for_Individuals_and_Companies.Entities
{
    internal abstract class TaxPayer
    {
        public string Name;
        public double AnualIncome;

        public TaxPayer()
        {
            
        }

        protected TaxPayer(string name, double anualIncome)
        {
            Name = name;
            AnualIncome = anualIncome;
        }

        public abstract double Tax();
    }
}
