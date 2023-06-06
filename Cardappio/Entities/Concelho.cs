using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class Concelho
    {
        public string NomeConcelho { get; set; }
        public Equipa Equipa { get; set; }

        //Construtores
        public Concelho()
        {
        }

        public Concelho(string nomeConcelho, Equipa equipa)
        {
            NomeConcelho = nomeConcelho;
            Equipa = equipa;
        }
        //Metodos
        public void EditarConcelho(string novoNomeConcelho)
        {
            NomeConcelho = novoNomeConcelho;
        }
    }
}