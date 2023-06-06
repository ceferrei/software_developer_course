using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    public class Contador
    {
        private static Contador instancia;
        private static int contador = 0;

        private Contador()
        {
        }

        public static Contador Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Contador();
                }
                return instancia;
            }
        }

        public int Proximo()
        {
            return ++contador;
        }

    }
}
