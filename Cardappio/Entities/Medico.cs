using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cardappio.Entities.Enums;

namespace Cardappio.Entities
{
    internal class Medico : Colaborador
    {

        // As propriedades serão herdadas de Colaborador



        // Construtores

        public Medico()
        {

        }

        public Medico(string nomeColaborador, string moradaColaborador, int contactoColaborador, string emailColaborador, double salario, DateTime dataNascimento, Equipa equipa, string username, int numeroCc, string password, string nib)
            : base(nomeColaborador, moradaColaborador, contactoColaborador, emailColaborador, salario, Profissao.Medico, dataNascimento, equipa, username, numeroCc, password, nib)
        {

        }

        // Escrever o relatório sobre o estado de saúde do Utente
        public void GerarRelatorioMedico(Utente utente)
        {
            if (Equipa.PesquisarRelatorioMedico(utente) != null) 
            {
                Console.WriteLine("O relatorio desse utente ja existe!");
                return;
            }

            Console.Write("Escreva o relatório médico: ");
            string resumo = Console.ReadLine();

            RelatorioMedico relatorioMedico = new RelatorioMedico(resumo, utente);
            Equipa.AdicionarRelatorioMedico(relatorioMedico);
            Console.Write("Relatório criado com sucesso!\n");
        }

        // Guardar o relatório
        public void GuardarRelatorio()
        {
            Console.WriteLine("Verifique o Relatório. Deseja guardar? (S/N) ");
        }

        public RelatorioMedico PesquisarRelatorioMedico()
        {
            Utente utente = Equipa.PesquisarUtente();
            return Equipa.PesquisarRelatorioMedico(utente);
        }
    }
}