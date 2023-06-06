using Cardappio.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class Autenticacao
    {
        private List<Colaborador> Colaboradores { get; set; }

        //CONSTRUTORES
        public Autenticacao() 
        {
            Colaboradores = new List<Colaborador>();
        }

        //METODOS
        public void AlterarCredenciais(string username, string novaPassword) 
        {
            foreach (Colaborador colaborador in Colaboradores)
            {
                if (colaborador.Username == username)
                {
                    colaborador.AlterarSenha(novaPassword);
                    return; // Sai do método após a alteração das credenciais
                }
            }
        }

        public Colaborador VerificarCredenciais(string username, string password) //recebe do program o username e password e verifica se coincidem com o que foi criado eguardado na lista posteriormente
        {
            foreach (Colaborador colaborador in Colaboradores)
            {
                if (colaborador.Username == username) //se o user da classe colaborador coincidir com o que o utilizador escreveu no terminal e se (ver linha a baixo)
                {
                    if (colaborador.VerificarPassword(password))// a password tambem estiver certa (temos de chamar este metodo por ser private),
                    {
                        Console.WriteLine("Login efetuado com sucesso!");
                        return colaborador; //Retorna um boleano da classe colaborador, mais precisamente do metodo verificarPass. se for true acertou e podemos prosseguir o programa
                    
                    }

                    Console.WriteLine("Password incorreta!");//se errou mostramos a mensagem de insucesso
                    return null;
                }
            }

            Console.WriteLine("Username inexistente!");
            return null; // o return neste contexto encerra o metodo de verificacao da autenticacao

        }
        
        public void AdicionarColaborador(Colaborador colaborador)
        {
            Colaboradores.Add(colaborador);
        }

        public Boolean VerificarUsername(string username)
        {
            foreach (Colaborador colaborador in Colaboradores)//Percorrer a lista
            {
                if (colaborador.Username == username) //Verificar se o user que ele inseriu ja existe na lista ou nao
                {
                    Console.WriteLine("O username inserido já existe!"); //se ja existir nao permite que crie conta porque o user é unico
                    return false; //retorna falso, o que quer dizer que nao pode escolher esse
                }
            }

            return true;//se o username estiver disponivel pode avançar.
        }
    }
}
