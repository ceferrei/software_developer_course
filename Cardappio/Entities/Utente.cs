using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class Utente
    {
        // Propriedades
        public int IdUtente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Morada { get; set; }
        public int Contacto { get; set; }
        public string Email { get; set; }
        public int NumeroSns { get; set; }
        public string Genero { get; set; }

        public bool Consentimento { get; set; }

        // Construtores
        public Utente()
        {

        }

        public Utente(int idUtente, string nome, DateTime dataNascimento, string morada, int contacto, string email, int numeroSns, string genero, bool consentimento)
        {
            IdUtente = idUtente;
            Nome = nome;
            DataNascimento = dataNascimento;
            Morada = morada;
            Contacto = contacto;
            Email = email;
            NumeroSns = numeroSns;
            Genero = genero;
            Consentimento = consentimento;
        }



        // Calcular a idade do Utente
        public int CalcularIdade()
        {
            DateTime dataAtual = DateTime.Today;
            int idade = dataAtual.Year - DataNascimento.Year;

            // Verificar se ainda não fez aniversário no ano atual
            if (dataAtual < DataNascimento.AddYears(idade))
            {
                idade--;
            }

            return idade;
        }
    }
}