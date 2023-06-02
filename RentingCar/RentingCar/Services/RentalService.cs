using RentingCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCar.Services
{
    internal class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }
        //public PortugalTaxService PortugalTaxService = new PortugalTaxService();
        public ITaxService TaxService;
        public RentalService()
        {
            
        }

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            TaxService = taxService;
        }



        //Método
        
        public void ProccesInvoice(CarRental carRental)
        {
            //Calculo da duração do aluguer de carro
            TimeSpan duration = carRental.Finish.Subtract(carRental.Finish);

            double basicPayment = 0.0;
            if(duration.TotalHours <= 12)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }
            double tax = TaxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
