using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class Equipa
    {
        public string NomeEquipa { get; set; }
        public Equipamento Equipamento { get; set; }
        List<Rastreio> Rastreios { get; set; }
        List<Utente> Utentes { get; set; }
        List<Deslocacao> Deslocacoes { get; set; }
        List<RelatorioMedico> RelatoriosMedico { get; set; }
        List<string> RelatoriosEstatisticos { get; set; }
        List<string> RelatoriosColabs { get; set; } 
        List<string> RelatoriosNumeroRastreios { get; set; }
        //Concelho Concelho { get; set; }
        private List<Colaborador> Colaboradores { get; set; }

        public Equipa()
        {

        }

        public Equipa(string nomeEquipa, Equipamento equipamento)
        {
            NomeEquipa = nomeEquipa;
            Equipamento = equipamento;
            Colaboradores = new List<Colaborador>();
            Rastreios = new List<Rastreio>();
            Utentes = new List<Utente>();
            Deslocacoes = new List<Deslocacao>();
            RelatoriosMedico = new List<RelatorioMedico>();
            RelatoriosEstatisticos = new List<string>();
            RelatoriosColabs = new List<string>();
            RelatoriosNumeroRastreios = new List<string>();
        }


        public List<Colaborador> GetColaboradores()
        {
            return Colaboradores;
        }
        public void EditarEquipa(string novoNome)
        {
            NomeEquipa = novoNome;
        }

        public Utente PesquisarUtente()
        {
            Console.Write("Insira o ID do utente que deseja pesquisar: ");
            int idUtente = int.Parse(Console.ReadLine());
            Utente utenteEncontrado = null;
            foreach (Utente utente in Utentes)
            {
                if (utente.IdUtente == idUtente)
                {
                    utenteEncontrado = utente;
                    break;
                }
            }

            if (utenteEncontrado == null)
            {
                Console.WriteLine("Utente não encontrado.");
            }

            return utenteEncontrado;
        }

        public Rastreio PesquisarRastreio()
        {
            Console.Write("Insira o Id do utente: ");
            int idUtente = int.Parse(Console.ReadLine());

            Rastreio rastreioEncontrado = null;
            foreach (Rastreio rastreio in Rastreios)
            {
                if (rastreio.Utente.IdUtente == idUtente)
                {
                    rastreioEncontrado = rastreio;
                    break;
                }
            }

            if (rastreioEncontrado == null)
            {
                Console.WriteLine("Rastreio não encontrado.");
            }

            return rastreioEncontrado;
        }

        public Deslocacao PesquisarUltimaDeslocacao()
        {
            if (Deslocacoes.Count == 0) return null;

            return Deslocacoes.Last();
        }

        public void CriarDeslocacao(Deslocacao deslocacao)
        {
            Deslocacoes.Add(deslocacao);
        }

        public void CriarRastreio(Rastreio rastreio)
        {
            Rastreios.Add(rastreio);
            Equipamento.RealizarAnalise(1, 1);// 1, 1 significa que nesta consulta usamos uma tira de colesterol e outra de glicose
        }
   
        public void EditarRastreio(Rastreio rastreio)
        {
            Rastreios.Add(rastreio);
        }

        // Metodos relatorios estatisticos

        public void AdicionarUtente(Utente utente)
        {
            Utentes.Add(utente);
        }

        public void AdicionarColaborador(Colaborador colaborador)
        {
            Colaboradores.Add(colaborador);
        }

        public void GerarRelatorioNumeroRastreios()
        {
            Console.WriteLine("Relatório Resumo de Consultas");
            Console.WriteLine("============================");

            int total = Rastreios.Count;
            Console.WriteLine("Número total de consultas: " + total);

            DateTime dataAtual = DateTime.Now;
            DateTime dataUltimoDia = dataAtual.AddDays(-1);
            int ultimoDia = Rastreios.Count(r => r.DataConsulta >= dataUltimoDia);
            Console.WriteLine("Número de consultas do último dia: " + ultimoDia);


            DateTime dataUltimaSemana = dataAtual.AddDays(-7);
            int ultimaSemana = Rastreios.Count(r => r.DataConsulta >= dataUltimaSemana);
            Console.WriteLine("Número de consultas da última semana: " + ultimaSemana);


            string relatorio = $"Relatório Resumo de Consultas\n============================\nNúmero total de consultas: {total}\nNúmero de consultas do último dia: {ultimoDia}\nNúmero de consultas da última semana: {ultimaSemana}";
            RelatoriosNumeroRastreios.Add(relatorio);
        }

        public void AdicionarRelatorioMedico(RelatorioMedico relatorioMedico)
        {
            RelatoriosMedico.Add(relatorioMedico);
        }

        public RelatorioMedico PesquisarRelatorioMedico(Utente utente)
        {
            RelatorioMedico relatorioMedicoEncontrado = null;
            foreach (RelatorioMedico relatorioMedico in RelatoriosMedico)
            {
                if (relatorioMedico.Utente.IdUtente == utente.IdUtente)
                {
                    relatorioMedicoEncontrado = relatorioMedico;
                    break;
                }
            }

            if (relatorioMedicoEncontrado == null)
            {
                Console.WriteLine("Relatório não encontrado.");
            }

            return relatorioMedicoEncontrado;
        }

        //Metodos relatorio Diario HTA (este metodo irá pecorrer os rastreios realizados no ultimo dia e verificar a classificação HTA para cada utente com base nos valores de pressão arterial

        public void GerarRelatorioEstatistico()
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataUltimoDia = dataAtual.AddDays(-1);

            List<Utente> utentesHTAGrau1 = new List<Utente>();
            List<Utente> utentesHTAGrau2 = new List<Utente>();
            List<Utente> utentesHTAGrau3 = new List<Utente>();

            foreach (Rastreio rastreio in Rastreios)
            {
                if (rastreio.DataConsulta >= dataUltimoDia)
                {
                    double pas = rastreio.PAS;
                    double pad = rastreio.PAD;

                    if ((pas > 140 && pas < 160) || (pad > 90 && pad < 100))
                    {
                        utentesHTAGrau1.Add(rastreio.Utente);
                    }
                    else if ((pas > 160 && pas < 180) || (pad > 100 && pad < 110))
                    {
                        utentesHTAGrau2.Add(rastreio.Utente);
                    }
                    else if (pas >= 180 || pad >= 110)
                    {
                        utentesHTAGrau3.Add(rastreio.Utente);
                    }
                }
            }

            string relatorio = "Relatório de HTA - Último dia\n------------------------------\n";
            relatorio += "HTA Grau 1:\n";
            foreach (Utente utente in utentesHTAGrau1)
            {
                relatorio += "- " + utente.Nome + "\n";
            }
            relatorio += "------------------------------\n";
            relatorio += "HTA Grau 2:\n";
            foreach (Utente utente in utentesHTAGrau2)
            {
                relatorio += "- " + utente.Nome + "\n";
            }
            relatorio += "------------------------------\n";
            relatorio += "HTA Grau 3:\n";
            foreach (Utente utente in utentesHTAGrau3)
            {
                relatorio += "- " + utente.Nome + "\n";
            }
            relatorio += "------------------------------";

            RelatoriosEstatisticos.Add(relatorio);//aqui acrescentei esta parte para pormos os relatorios em listas, para isso fui concatenando a informacao numa var relatorio
            Console.WriteLine(relatorio);
        }

        public void GerarRelatorioColab()
        {
            string relatorio = "Relatório de Colaboradores\n";

            foreach (Colaborador colaborador in Colaboradores)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                relatorio += $"Nome: {colaborador.NomeColaborador}\n";
                relatorio += $"Vencimento: {colaborador.Salario.ToString("F2", CultureInfo.InvariantCulture)}\u20AC\n";
                relatorio += $"Equipa: {colaborador.Equipa.NomeEquipa}\n";
            }

            RelatoriosColabs.Add(relatorio);
            Console.WriteLine(relatorio);
            
        }

        public void MostrarEquipamento()
        {
            Equipamento.MostrarStock();
        }

        //é pecorrido os rastreios realizados no ultimo dia (usando a variavel dataUltimoDia) e verificar a classificação HTA com base nos valores de pressão arterial
        //(que estão armazenados nos atributos PAS e PAD da classe rastreio).Os utentes são agrupados em listas de acordo com a sua classificação
    }
}
