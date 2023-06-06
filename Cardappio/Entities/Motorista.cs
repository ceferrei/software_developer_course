using Cardappio.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class Motorista : Colaborador
    {
        //DECLARAÇÃO DE PROPRIEDADES DA CLASSE MOTORISTA - cada propriedade (autoimplementada) possui um tipo de dado e metodos de atribuição (get e set) associados
        //Estas propriedades permitem que se possa acessar e modificar os dados de forma controlada
        //(p.ex: podemos ao acessar à propriedade 'Nome' podemos obter o valor actual(get) ou atribuir un novo valor (get)->oferece maior encapsulamento e flexibilidade)


        //Construtor padrão

        public Motorista()
        {

        }

        public Motorista(string nomeColaborador, string moradaColaborador, int contactoColaborador, string emailColaborador, double salario, DateTime dataNascimento, Equipa equipa, string username, int numeroCc, string password, string nib)
            : base(nomeColaborador, moradaColaborador, contactoColaborador, emailColaborador, salario, Profissao.Motorista, dataNascimento, equipa, username, numeroCc, password, nib)
        {
        }

        //METODOS 

        //Método RegistarDeslocacao---é responsavel por soliciatar informações ao motorista sobre a deslocação e actualizar as propriedades correspondentes na classe motorista
        // método para registar a deslocação 
        public void RegistarDeslocacao()
        {
            Console.WriteLine("Registo de Quilometragem e Combustível:\n");

            Console.Write("Insira a matrícula da viatura: ");
            string matricula = Console.ReadLine();

            Console.Write("Insira a data da deslocação (dd/MM/yyyy): ");
            DateTime dataDeslocacao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Registe a quilometragem inicial(km): ");
            int kmInicial = int.Parse(Console.ReadLine());

            Console.Write("Registe a quilometragem final(km): ");
            int kmFinal = int.Parse(Console.ReadLine());

            Console.Write("Necessitou de abastecer o veículo? (Sim/Não) ");
            string resposta = Console.ReadLine(); 
            Boolean abasteceuVeiculo = resposta.ToLower() == "sim"; // converte a resposta para minusculas e compara com a string "sim" pelo operador de igualdade (==)--->true ou false

            //AbasteceuVeiculo = respostaAbast == "Sim"; //o operador == é usado para comparar directamente a string 'respostaAbast' com a string'Sim', sem distinção entre maiusculas e minusculaas

            if (abasteceuVeiculo)
            {
                Console.Write("Introduza os litros de combustível: ");
                double litrosCombustivel = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Introduza o valor pago: ");
                double valorPago = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Introduza o número do cartão frota utilizado: ");
                long cartaoFrota = long.Parse(Console.ReadLine());

                Deslocacao deslocacao = new Deslocacao(matricula, dataDeslocacao, kmInicial, abasteceuVeiculo, kmFinal, litrosCombustivel, valorPago, cartaoFrota);
                Equipa.CriarDeslocacao(deslocacao);
            } else
            {
                Deslocacao deslocacao = new Deslocacao(matricula, dataDeslocacao, kmInicial, abasteceuVeiculo, kmFinal);
                Equipa.CriarDeslocacao(deslocacao);
            }

        }
        public void RelatorioKm()
        {
            Deslocacao deslocacao = Equipa.PesquisarUltimaDeslocacao();

            if (deslocacao != null)
            {
                Console.WriteLine("\nRelatório de Quilometragem\n");
                Console.WriteLine($"Matrícula da viatura: {deslocacao.Matricula}");
                Console.WriteLine($"Motorista: {NomeColaborador} da equipa {Equipa.NomeEquipa}");

                Console.WriteLine($"Data da deslocação: {deslocacao.DataDeslocacao.ToString()}");
                Console.WriteLine($"Quilometragem percorrida: {deslocacao.Km} km");

                if (deslocacao.AbasteceuVeiculo)
                {
                    Console.WriteLine("Informações de abastecimento:");
                    Console.WriteLine($"Litros de combustível: {deslocacao.LitrosCombustivel}");
                    Console.WriteLine($"Valor pago: {deslocacao.ValorPago}");
                    Console.WriteLine($"Número do cartão frota utilizado: {deslocacao.CartaoFrota}");
                }

                Console.WriteLine("----------------------");
            }

        }
    }
}


