using Cardappio.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace Cardappio.Entities
{
    internal class Administrativo : Colaborador
    {
        public Administrativo()
        {

        }

        public Administrativo(string nomeColaborador, string moradaColaborador, int contactoColaborador, string emailColaborador, double salario, DateTime dataNascimento, Equipa equipa, string username, int numeroCc, string password, string nib)
            : base(nomeColaborador, moradaColaborador, contactoColaborador, emailColaborador, salario, Profissao.Administrativo, dataNascimento, equipa, username, numeroCc, password, nib)
        {            
        }


        public void InserirUtente() //Vazio porque utente ainda nao possui id, vai ser criado o id neste metodo assim como o resto dos dados
        {
            Console.WriteLine("Inserir dados do utente:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Morada: ");
            string morada = Console.ReadLine();

            Console.Write("Contacto: ");
            int contacto = int.Parse(Console.ReadLine());

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Data de Nascimento (dd/MM/yyyy): ");
            DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Número de SNS: ");
            int numeroSns = int.Parse(Console.ReadLine());

            Console.Write("Género: ");
            string genero = Console.ReadLine();

            Console.Write("Consentimento informado assinado (Sim/Não): ");
            bool consentimento = Console.ReadLine().ToLower() == "sim";

            //É criado o novo utente e enviados os dados dele para a lista
            Utente novoUtente = new Utente(Contador.Instancia.Proximo(), nome, dataNascimento, morada, contacto, email, numeroSns, genero, consentimento); //carregado o novoUtente com a informacao

            Equipa.AdicionarUtente(novoUtente); //adicionado novoUtente à lista de utentes
            Console.WriteLine($"Utente {novoUtente.IdUtente} inserido com sucesso!\n");
        }

        public void EditarUtente(Utente utente) //variavel utente que vem do program e traz a informacao do id
        {
            Console.WriteLine("Editar dados do utente:");
            
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Morada: ");
            string morada = Console.ReadLine();

            Console.Write("Contacto: ");
            int contacto = int.Parse(Console.ReadLine());

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Data de Nascimento (dd/MM/yyyy): ");
            DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Número de SNS: ");
            int numeroSns = int.Parse(Console.ReadLine());

            Console.Write("Consentimento informado assinado (Sim/Não): ");
            bool consentimento = Console.ReadLine().ToLower() == "sim";

            // Atualizar as informações do utente
            utente.Nome = nome;
            utente.Morada = morada;
            utente.Contacto = contacto;
            utente.Email = email;
            utente.DataNascimento = dataNascimento;
            utente.NumeroSns = numeroSns;
            utente.Consentimento = consentimento;

            Console.WriteLine("Dados do utente atualizados com sucesso!\n");
        }

        public void MostrarUtente(Utente utente)
        {
            Console.Write($"Nome: {utente.Nome}\n");
            Console.Write($"Morada: {utente.Morada}\n");
            Console.Write($"Contacto: {utente.Contacto}\n");
            Console.Write($"Email: {utente.Email}\n");
            Console.Write($"Data de Nascimento: {utente.DataNascimento}\n");
            Console.Write($"Número de SNS: {utente.NumeroSns}\n");
            Console.Write($"Consentimento: {utente.Consentimento}\n\n");
        }
    

        public void EnviarConvocatoria(Utente utente) //utente entre parenteses para receber a informacao do program
        {
            Console.WriteLine("Enviar convocatória para utente:");

            Console.Write("Data do Rastreio: ");
            string dataRastreio = Console.ReadLine();

            Console.Write("Local do Rastreio: ");
            string localRastreio = Console.ReadLine();

            string email = $"Convocatória para rastreio:\nData: {dataRastreio}\nLocal: {localRastreio}";

            Console.WriteLine($"Enviando Email para: {utente.Email}");
            Console.WriteLine($"Mensagem: {email}");

            // Definimos sucesso de envio como true
            bool envioSucesso = true;

            if (envioSucesso)
            {
                Console.WriteLine($"Convocatória enviada com sucesso.");
            }
            else
            {
                Console.WriteLine("Falha ao enviar a convocatória.");
                return;
            }
        }
    }
}