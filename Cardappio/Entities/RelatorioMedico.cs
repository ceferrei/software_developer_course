using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class RelatorioMedico
    {
        public Utente Utente { get; set; }
        public string Sumario;
        public RelatorioMedico() { }

        public RelatorioMedico(string sumario, Utente utente)
        {
            Sumario = sumario;
            Utente = utente;
        }

        public void MostrarRelatorioMedico()
        {
            Console.WriteLine("Utente: " + Utente.Nome);
            Console.WriteLine("Sumario: " + Sumario);
        }

        public void EditarRelatorioMedico()
        {
            Console.WriteLine("Escreva o novo sumario para este relatorio: ");
            Sumario = Console.ReadLine();
            Console.WriteLine("Relatorio editado!");
        }
    }
}
