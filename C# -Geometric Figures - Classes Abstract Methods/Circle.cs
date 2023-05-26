using Geometric_Figures___Classes_Abstract_Methods.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Geometric_Figures___Classes_Abstract_Methods.Entities
{
    internal class Circle: Shape
    {
        public double Radius { get; set; }

        public Circle()
        {
            
        }

        public Circle(double radius, Color color) 
            :base(color)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
