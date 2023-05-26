using Geometric_Figures___Classes_Abstract_Methods.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometric_Figures___Classes_Abstract_Methods.Entities
{
    internal abstract class Shape
    {
        public Color Color { get; set; }

        public Shape()
        {
            
        }

        public Shape(Color color)
        {
            Color = color;
        }


        //Métodos
        //Shape apenas tem um método: Area()
        //Este método é abstrato( enunciado) pq apenas apresentamos a assinatura dele
        public abstract double Area();
    

        
    }

}
