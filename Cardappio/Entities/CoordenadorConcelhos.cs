using Cardappio.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class CoordenadorConcelhos
    {
        private List<Concelho> Concelhos = new List<Concelho>();

        //Construtores
        

        public CoordenadorConcelhos()
        {
            Concelhos = new List<Concelho>();
            Equipa equipaAmares = new Equipa("Equipa Amares", new Equipamento(10, 10));
            Equipa equipaBraga = new Equipa("Equipa Braga", new Equipamento(10, 10));
            Equipa equipaGuimaraes = new Equipa("Equipa Guimarães", new Equipamento(10, 10));


            Concelhos.Add(new Concelho("Amares", equipaAmares));
            Concelhos.Add(new Concelho("Braga", equipaBraga));
            Concelhos.Add(new Concelho("Guimarães", equipaGuimaraes));

            Colaborador laura = new Colaborador("Laura Cardoso", "Rua da Gaivota", 999999999, "laura.cardoso@gmail.com", 1500, Enums.Profissao.Enfermeiro, new DateTime(1990, 3, 7), equipaBraga, "enflaura", 11111111, "passlaura", "22222222222222222222");
            Colaborador lucio = new Colaborador("Lucio Dias", "Rua da Praça", 999999999, "lucio.dias@gmail.com", 2000, Enums.Profissao.Medico, new DateTime(1990, 9, 1), equipaBraga, "medlucio", 11111111, "passlucio", "3333333333333333333");
            Colaborador sara = new Colaborador("Sara Formoso", "Rua da Alegria", 999999999, "sara.formoso@gmail.com", 1000, Enums.Profissao.Motorista, new DateTime(1990, 8, 8), equipaBraga, "motsara", 11111111, "passsara", "44444444444444444444");
            Colaborador cecilia = new Colaborador("Cecilia Marçal", "Rua da Nave", 999999999, "cecilia.marçal@gmail.com", 950.50, Enums.Profissao.Administrativo, new DateTime(1990, 2, 9), equipaBraga, "admcecilia", 11111111, "passcecilia", "55555555555555555555");

            equipaBraga.AdicionarColaborador(laura);
            equipaBraga.AdicionarColaborador(lucio);
            equipaBraga.AdicionarColaborador(sara);
            equipaBraga.AdicionarColaborador(cecilia);

            Utente utente1 = new Utente(1, "Utente1", new DateTime(1990, 3, 7), "Rua da Avenida", 999999999, "exemplo@gmailcom", 292311112, "Masculino", true);
            Utente utente2 = new Utente(2, "Utente2", new DateTime(1990, 3, 7), "Rua da Terra", 999999999, "exemplo2@gmailcom", 999232312, "Masculino", true);

            equipaBraga.AdicionarUtente(utente1);
            equipaBraga.AdicionarUtente(utente2);

            Rastreio rastreio1 = new Rastreio(utente1, new DateTime(2023, 06, 06), "Diabetes", true, true, true, true, false, false, 54.8, 1.67, 240,120, 200, 200 );


            equipaBraga.CriarRastreio(rastreio1);

            RelatorioMedico relatorioMedico1 = new RelatorioMedico("Utente com sintomas de XPTO, sugiro ABCD", utente1);

            equipaBraga.AdicionarRelatorioMedico(relatorioMedico1);

        }


        //Metodos

        public void AdicionarColabAutenticacao(Autenticacao autenticacao)
        {
            foreach (Concelho concelho in Concelhos)
            {
                List<Colaborador> colaboradores = concelho.Equipa.GetColaboradores();
                foreach(Colaborador colaborador in colaboradores)
                {
                    autenticacao.AdicionarColaborador(colaborador);
                }
            }
        }
        public void AddConcelho(Concelho concelho)
        {
            Concelhos.Add(concelho);
        }
        public void RemConcelho(Concelho concelho)
        {
            Concelhos.Remove(concelho);
        }

        public void MostrarConcelhos()
            //Percorre a lista dos concelhos para mostrar o concelho, o equipamento que possui e a equipa que está ligada a ele
        {
            Console.WriteLine("Concelhos disponíveis:");
            foreach (Concelho concelho in Concelhos)
            {
                Console.WriteLine("Nome do concelho: " + concelho.NomeConcelho);
                Console.WriteLine("Equipamento: " + concelho.Equipa.Equipamento);

                Console.WriteLine("Equipa: " + concelho.Equipa.NomeEquipa);
            }
        }

        public Concelho VerificarConcelho(string nomeConcelho) //método para guardar equipas
        {
            foreach (Concelho concelho in Concelhos) //Percorre os concelhos ate encontrar na lista o que o utilizador digitou
            {
                if (concelho.NomeConcelho.ToLower() == nomeConcelho.ToLower()) 
                {
                    return concelho;//Se encontrar retorna esse concelho
                }
            }

            Console.WriteLine("Concelho inexistente!\n"); //Escreveu errado ou introduziu um concelho que nao esta listado (Existe amares, braga e guimarães)
            return null;
        }
    }
}
