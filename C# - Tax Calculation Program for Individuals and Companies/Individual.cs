using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Calculation_Program_for_Individuals_and_Companies.Entities
{
    internal class Individual : TaxPayer
    {

        public double HealthExpenditures;

        public Individual(double healthExpenditures, string name, double anualIncome) : base(name, anualIncome)
        {
            HealthExpenditures = healthExpenditures;

        }

        public override double Tax()
        {
            double tax = 0;

            if (AnualIncome < 20000)
            {
                tax = AnualIncome * 0.15;
                if (HealthExpenditures > 0)
                {
                    tax -= HealthExpenditures * 0.5;
                }
            }
            else
            {
                tax = AnualIncome * 0.25;
                if (HealthExpenditures > 0)
                {
                    tax -= HealthExpenditures * 0.5; // sao abatidos 50% caso tenha gatos de saude
                }
            }
            return tax;
            
        }
    }
}
