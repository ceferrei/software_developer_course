using Cardappio.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class Enfermeiro : Colaborador
    {
        
        public Enfermeiro()
        {
        }

        public Enfermeiro(string nomeColaborador, string moradaColaborador, int contactoColaborador, string emailColaborador, double salario, DateTime dataNascimento, Equipa equipa, string username, int numeroCc, string password, string nib)
            : base(nomeColaborador, moradaColaborador, contactoColaborador, emailColaborador, salario, Profissao.Enfermeiro, dataNascimento, equipa, username, numeroCc, password, nib)
        { 
           
        }

        public void CriarRastreio()
        {
            Utente utenteEncontrado = Equipa.PesquisarUtente();

            if (utenteEncontrado == null)
            {
                return;
            }

            if (Equipa.Equipamento.StockColesterol == 0 || Equipa.Equipamento.StockGlicose == 0)
            {
                Console.WriteLine("Quantidade de stock esgotada.");
                return;
            }

            Rastreio rastreio = new Rastreio(utenteEncontrado, DateTime.Now);

            rastreio.SetDadosRastreio();
            Equipa.CriarRastreio(rastreio);

            rastreio.MostrarDadosRastreio();
        }

        public void EditarRastreio()
        {
            Rastreio rastreio = Equipa.PesquisarRastreio();
            rastreio.SetDadosRastreio();
        }
    }
}
