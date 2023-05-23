using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Registration_and_Payments
{
    internal class OutsourcedEmployee: Employee
    {
        public double AdditionalCharge { get; set; }

        public OutsourcedEmployee()
        {
            
        }

        public OutsourcedEmployee(double additionalCharge, string name, int hours, double valuePerHour) 
            :base(name, hours, valuePerHour)
        {
            AdditionalCharge = additionalCharge;
        }
        public override double Payment()
        {
            return base.Payment() + AdditionalCharge * 1.1;
        }


    }
}
