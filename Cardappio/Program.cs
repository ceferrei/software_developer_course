using Cardappio.Entities.Enums;
using Cardappio.Entities;
using System;
using System.Diagnostics.Contracts;
using System.Globalization;

internal class Program //A palavra-chave internal é um modificador de acesso que indica que a classe Program só é visível dentro do assembly em que está definida. Isso significa que outras classes fora do assembly não podem acessar a classe
{
    //responsável por verificar se a resposta fornecida é "sim" ou "não" (tanto em letras minúsculas quanto maiúsculas). Se for uma resposta válida, retorna true. Caso contrário, exibe uma mensagem de erro com a resposta incorreta e retorna false
    private static Boolean VerificarResposta(string resposta)
    {
        if (resposta != null && resposta.ToLower() == "sim")
        {
            return true; // A resposta foi escrita corretamente
        }
        else if (resposta != null && (resposta.ToLower() == "não" || resposta.ToLower() == "nao"))
        {
            return true; // A resposta foi escrita corretamente
        }
        else
        {
            Console.WriteLine("Resposta incorreta: " + resposta);
            // Exibe o que foi introduzido para o utilizador verificar o que introduziu erradamente
            return false;
        }
       
    }
    //é declarado como estático porque precisa ser chamado sem criar um objeto da classe Program. É necessário porque o sistema precisa ter um ponto de entrada fixo para iniciar a execução do programa
    private static void Main(string[] args) 
    {
        Autenticacao autenticacao = new Autenticacao(); //inicializamos a autenticacao para ser utilizada
        CoordenadorConcelhos coordenadorConcelhos = new CoordenadorConcelhos();//inicializamos a classe para ser utilizada
        coordenadorConcelhos.AdicionarColabAutenticacao(autenticacao); //adiciona os colaboradores à autenticação
        

        Console.WriteLine("Bem-vindo/a à aplicação Cardappio!");
        bool fezLogin = false;
        Console.WriteLine();
        Console.Write("Já possui uma conta? (Sim/Não): ");
        string temConta = Console.ReadLine();
        while (!VerificarResposta(temConta))//Vai à função acima. enquanto não responder "sim" ou "não" continua neste loop. Caso a resposta seja "nim" ou outra coisa qualquer é repetida a pergunta
        {
            Console.Write("Já possui uma conta? (Sim/Não): ");
            temConta = Console.ReadLine();
        }

        Colaborador colaborador = null; //Iniciamos a null para preparar a variável para as duas possibilidades: iniciar sessao ou criar conta
        if (temConta.ToLower() == "sim") //se já tem conta entao vai fazer login
        {
            while (!fezLogin)
            {
                Console.WriteLine();
                Console.Write("Insira o seu username: ");
                string username = Console.ReadLine();
                Console.Write("Insira a sua password: ");
                string password = Console.ReadLine();

                colaborador = autenticacao.VerificarCredenciais(username, password); //método da classe autenticaçao
                if (colaborador != null)
                {
                    fezLogin = true; //se saiu deste loop é porque introduziu corretamente as credenciais
                }
            }
        }

        else //inicio do bloco de criação de conta no caso de o profissional ainda não possuir
        {
            Console.WriteLine("Crie o seu perfil profissional:");
            while (!fezLogin)
            {
                Console.Write("Escolha um username: ");
                string username = Console.ReadLine();

                if (!autenticacao.VerificarUsername(username))//método da classe autenticaçao
                {//utilização de "not": se for inserido um username que ainda nao existe, ele retornou True ( de disponivel) mas usando o "not (!)"  estamos a dizer:
                 //se not true, quer dizer que escolheu um nome ja existente
                    
                    continue;// Faz com que o fluxo do programa volte ao início do loop mais próximo, neste caso o while( é da mesma familia que o break, fazem o contrário um do outro)
                             //o que significa que lhe vai ser pedido novamemte; escolha um username.
                }

                Console.Write("Escolha a sua password: ");
                string password = Console.ReadLine();

                Concelho concelho = null;
                while (concelho == null)
                {
                    Console.Write("Insira o concelho da Equipa: ");
                    string nomeConcelho = Console.ReadLine();

                    concelho = coordenadorConcelhos.VerificarConcelho(nomeConcelho); //mesmo raciocinio usado anteriormente
                }

                Console.Write("Insira o seu nome completo: ");
                string nomeCompleto = Console.ReadLine();

                Console.Write("Indique o cargo a desenvolver dentro da equipa: (1) Administrativo/a, (2) Enfermeiro/a, (3) Médico/a, (4) Motorista: ");
                Profissao profissao = Enum.Parse<Profissao>(Console.ReadLine());

                Console.Write("Insira a sua data de nascimento (MM/dd/yyyy): ");
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

                Console.Write("Insira o número do seu Cartão de Cidadão: ");
                int numeroCc = int.Parse(Console.ReadLine());

                Console.Write("Insira o seu NIB: ");
                string nib = Console.ReadLine();

                Console.Write("Insira a sua Morada: ");
                string morada = Console.ReadLine();

                Console.Write("Insira o seu contacto telefónico: ");
                int contacto = int.Parse(Console.ReadLine());

                Console.Write("Insira o seu Email: ");
                string email = Console.ReadLine();

                Console.Write("Insira o seu vencimento mensal: ");
                double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);



                colaborador = new Colaborador(nomeCompleto, morada, contacto, email, salario, profissao, dataNascimento, concelho.Equipa, username, numeroCc, password, nib); //aqui finalmente enviamos os dadoscompletos
                concelho.Equipa.AdicionarColaborador(colaborador);
                autenticacao.AdicionarColaborador(colaborador);

                Console.WriteLine("Perfil criado com sucesso!\n");
                fezLogin = true;

            }
        }


        while (fezLogin)
        {
            

            switch (colaborador.Profissao)
            {
                case Profissao.Administrativo:
                    Console.WriteLine();
                    Console.Write("Deseja: (1) Inserir utente, (2) Editar utente, (3) Enviar email de convocatória, (4) Gerar relatório, (5) Mostrar utente, (6) Fechar Aplicação: ");
                    int respAdm = int.Parse(Console.ReadLine());
                    Administrativo administrativo = new Administrativo(colaborador.NomeColaborador, colaborador.MoradaColaborador, colaborador.ContactoColaborador, colaborador.EmailColaborador, colaborador.Salario, colaborador.DataNascimento, colaborador.Equipa, colaborador.Username, colaborador.NumeroCc, colaborador.Password, colaborador.Nib); //instanciamos para podermos usar o objeto administrativo

                    if (respAdm == 1)
                    {
                        administrativo.InserirUtente();//classe administrativo
                    }
                    else if (respAdm == 2)
                    {
                        
                        Utente utente = administrativo.Equipa.PesquisarUtente();//Pesquisa pelo IdUtente para verificar se existe e de seguida o podermos editar
                        administrativo.EditarUtente(utente); //Caso exista podemos enviar esse utente para o metodo editarUtente em "administrativo"
                    }
                    else if (respAdm == 3)
                    { 
                        Utente utente = administrativo.Equipa.PesquisarUtente();

                        administrativo.EnviarConvocatoria(utente);
                    }
                    else if (respAdm == 4)
                    {
                        Console.Write("Que relatórios pretende gerar? (1) Relatório de Colaboradores, (2) Relatório Número de Rastreios, (3) Relatório estatististico de resultados: ");
                        int respRel = int.Parse(Console.ReadLine());

                        if (respRel == 1)
                        {
                            administrativo.Equipa.GerarRelatorioColab(); //método de "administrativo" onde irão ser feitas as questões
                        }
                        else if (respRel == 2)
                        {
                            administrativo.Equipa.GerarRelatorioNumeroRastreios();
                        }
                        else if (respRel == 3)
                        {
                            administrativo.Equipa.GerarRelatorioEstatistico();
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida. Tente novamente.");
                        }
                    } 
                    else if (respAdm == 5)
                    {
                        Utente utente = administrativo.Equipa.PesquisarUtente();
                        administrativo.MostrarUtente(utente);
                    }

                    else if(respAdm == 6)
                    {
                        return;
                    }
                    break;

                case Profissao.Enfermeiro:
                    Enfermeiro enfermeiro = new Enfermeiro(colaborador.NomeColaborador, colaborador.MoradaColaborador, colaborador.ContactoColaborador, colaborador.EmailColaborador, colaborador.Salario, colaborador.DataNascimento, colaborador.Equipa, colaborador.Username, colaborador.NumeroCc, colaborador.Password, colaborador.Nib);
                    Console.WriteLine();
                    Console.Write("Escolha a ação pretendida: (1) Iniciar rastreio, (2) Editar rastreio, (3) Mostrar rastreio, (4) Mostrar Equipamento Disponivel, (5) Fechar Aplicação: ");
                    int respEnf = int.Parse(Console.ReadLine());

                    if (respEnf == 1)
                    {
                        enfermeiro.CriarRastreio();
                    }

                    else if (respEnf == 2)
                    {
                        enfermeiro.EditarRastreio();
                    }

                    else if (respEnf == 3)
                    {
                        Rastreio rastreio = enfermeiro.Equipa.PesquisarRastreio();
                        rastreio.MostrarDadosRastreio();
                    }
                    else if (respEnf == 5)
                    {
                        enfermeiro.Equipa.MostrarEquipamento();
                    }
                    else if (respEnf == 4)
                    {
                        return;
                    }
                    break;

                case Profissao.Medico:
                    Medico medico = new Medico(colaborador.NomeColaborador, colaborador.MoradaColaborador, colaborador.ContactoColaborador, colaborador.EmailColaborador, colaborador.Salario, colaborador.DataNascimento, colaborador.Equipa, colaborador.Username, colaborador.NumeroCc, colaborador.Password, colaborador.Nib); //instanciamos para podermos usar o objeto administrativo
                    Console.WriteLine();
                    Console.Write("Escolha a ação pretendida: (1) Iniciar relatório médico, (2) Editar relatório médico , (3) Consultar relatório médico (4) Fechar Aplicação: ");
                    int respMed = int.Parse(Console.ReadLine());

                    if (respMed == 1)
                    {
                       Rastreio rastreio = medico.Equipa.PesquisarRastreio();
                       rastreio.MostrarDadosRastreio();
                       medico.GerarRelatorioMedico(rastreio.Utente);
                    }

                    else if (respMed == 2)
                    {
                        RelatorioMedico relatorioMedico = medico.PesquisarRelatorioMedico();
                        relatorioMedico.MostrarRelatorioMedico();
                        relatorioMedico.EditarRelatorioMedico();
                    }

                    else if(respMed == 3)
                    {
                        RelatorioMedico relatorioMedico = medico.PesquisarRelatorioMedico();
                        relatorioMedico.MostrarRelatorioMedico();    
                    }

                    else if (respMed == 4)
                    {
                        return;
                    }

                    break;
                case Profissao.Motorista:
                    Motorista motorista = new Motorista(colaborador.NomeColaborador, colaborador.MoradaColaborador, colaborador.ContactoColaborador, colaborador.EmailColaborador, colaborador.Salario, colaborador.DataNascimento, colaborador.Equipa, colaborador.Username, colaborador.NumeroCc, colaborador.Password, colaborador.Nib); //instanciamos para podermos usar o objeto administrativo
                    Console.WriteLine();
                    Console.Write("Escolha a ação pretendida: (1) Registar Deslocação, (2) Gerar relatório de quilómetros, (3) Fechar Aplicação: ");
                    int respMot = int.Parse(Console.ReadLine());

                    if (respMot == 1)
                    {
                        motorista.RegistarDeslocacao();
                    }

                    else if (respMot == 2)
                    {
                        motorista.RelatorioKm();
                    }
                    else if (respMot == 3)
                    {
                        return;
                    }

                    break;
                default:
                    Console.WriteLine("Profissão inválida.\n");
                    break;
            }
        }
    }
}