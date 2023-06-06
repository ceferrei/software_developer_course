using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class Anamnese
    {
        public string ListaAntecedentes { get; set; }
        public int NumUtente { get; set; }
        public bool AntiHipertensor { get; set; }
        public bool AntiDislipidemicos { get; set; }
        public int IdMedicacaoAtual { get; set; }
        public bool Fumador { get; set; }

        public Anamnese()
        {
        }

        public Anamnese(int numUtente, string listaAntecedentes, bool antiHipertensor, bool antiDislipidemicos, int idMedicacaoAtual, bool fumador)
        {
            NumUtente = numUtente;
            ListaAntecedentes = listaAntecedentes;
            AntiHipertensor = antiHipertensor;
            AntiDislipidemicos = antiDislipidemicos;
            IdMedicacaoAtual = idMedicacaoAtual;
            Fumador = fumador;
        }

        public void AdicionarAntecedente(string novoAntecedente)
        {
            if (novoAntecedente != null && novoAntecedente != "")
            {
                if (ListaAntecedentes == null)
                {
                    ListaAntecedentes = novoAntecedente;
                }
                else
                {
                    ListaAntecedentes += ", " + novoAntecedente;
                }
            }
        }

        public void EditarRelatorioAntecedentes(string novoRelatorio)
        {
            ListaAntecedentes = novoRelatorio;
        }
    }
}


