using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class Deslocacao
    {
        public string Matricula { get; set; }
        public DateTime DataDeslocacao { get; set; }
        public int KmInicial { get; set; }
        public bool AbasteceuVeiculo { get; set; }
        public double LitrosCombustivel { get; set; }
        public double ValorPago { get; set; }
        public long CartaoFrota { get; set; }
        public int KmFinal { get; set; }
        public int Km { get; set; }

        public Deslocacao() { }

        public Deslocacao(string matricula, DateTime dataDeslocacao, int kmInicial, bool abasteceuVeiculo, int kmFinal, double litrosCombustivel, double valorPago, long cartaoFrota)
        {
            Matricula = matricula;
            DataDeslocacao = dataDeslocacao;
            KmInicial = kmInicial;
            AbasteceuVeiculo = abasteceuVeiculo;
            LitrosCombustivel = litrosCombustivel;
            ValorPago = valorPago;
            CartaoFrota = cartaoFrota;
            KmFinal = kmFinal;
            Km = kmFinal - kmInicial;
        }

        public Deslocacao(string matricula, DateTime dataDeslocacao, int kmInicial, bool abasteceuVeiculo, int kmFinal)
        {
            Matricula = matricula;
            DataDeslocacao = dataDeslocacao;
            KmInicial = kmInicial;
            AbasteceuVeiculo = abasteceuVeiculo;
            LitrosCombustivel = 0;
            ValorPago = 0;
            CartaoFrota = 0;
            KmFinal = kmFinal;
            Km = kmFinal - kmInicial;
        }
    }
}
