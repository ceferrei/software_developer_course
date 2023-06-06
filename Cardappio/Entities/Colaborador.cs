using Cardappio.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class Colaborador
    {
        //DECLARAÇÃO DE PROPRIEDADES DA CLASSE - cada propriedade (autoimplementada) possui um tipo de dado e metodos de atribuição (get e set) associados
        //Estas propriedades permitem que se possa acessar e modificar os dados de forma controlada
        //(p.ex: podemos ao acessar à propriedade 'Nome' podemos obter o valor actual(get) ou atribuir un novo valor (get)->oferece maior encapsulamento e flexibilidade)
        public string NomeColaborador { get; set; }
        public string MoradaColaborador { get; set; }
        public int ContactoColaborador { get; set; }
        public string EmailColaborador { get; set; }
        public double Salario { get; set; }
        public string Nib { get; set; }
        public Profissao Profissao { get; set; }
        public DateTime DataNascimento { get; set; }
        public Equipa Equipa { get; set; }
        public string Username { get; set; }
        public int NumeroCc { get; set; }
        public string Password { get; private set; }
        public Colaborador()
        {
            
        }

        public Colaborador(string nomeColaborador, string moradaColaborador, int contactoColaborador, string emailColaborador, double salario, Profissao profissao, DateTime dataNascimento, Equipa equipa, string username, int numeroCc, string password, string nib)
        {
            NomeColaborador = nomeColaborador;
            MoradaColaborador = moradaColaborador;
            ContactoColaborador = contactoColaborador;
            EmailColaborador = emailColaborador;
            Salario = salario;
            Profissao = profissao;
            DataNascimento = dataNascimento;
            Equipa = equipa;
            Username = username;
            NumeroCc = numeroCc;
            Password = password;
            Nib = nib;
        }


        public void AlterarSenha(string novaPass)
        {
            Password = novaPass;
        }

        public Boolean VerificarPassword(string password)//vem da autenticacao e tem de verificar aqui a pass por ser privada
        {
            return password == Password; //retorna verdadeiro ou falso
        }
    }
}
