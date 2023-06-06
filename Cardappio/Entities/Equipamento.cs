using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class Equipamento
    {
        public int StockGlicose { get; set; }
        public int StockColesterol { get; set; }

        public Equipamento()
        {

        }

        public Equipamento(int stockGlicose, int stockColesterol)
        {
            StockGlicose = stockGlicose;
            StockColesterol = stockColesterol;
        }

        //METODOS

        public void RealizarAnalise(int tirasColUtilizadas, int tirasGliUtilizadas)// estes dois ints vem de equipa, carregadas com o numero 1 cada uma
        {
            StockColesterol -= tirasColUtilizadas;
            StockGlicose -= tirasGliUtilizadas;
        }

        public void AdicionarStock(int tirasColAdicionadas, int tirasGliAdicionadas)
        {
            StockColesterol += tirasColAdicionadas;
            StockGlicose += tirasGliAdicionadas;
        }

        public void MostrarStock()
        {
            Console.WriteLine("Stock atual de Tiras de Colesterol:" + StockColesterol);
            Console.WriteLine("Stock atual de tiras de Glicose:" + StockGlicose);

        }



    }
}
