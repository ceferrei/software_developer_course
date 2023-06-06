using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class Rastreio
    {
        public Utente Utente { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Antecedentes { get; set; }
        public bool AntiHipertensor { get; set; }
        public bool AntiDislipidemicos { get; set; }
        public bool DoencaCerebroVascular { get; set; }
        public bool DoencaCardiaca { get; set; }
        public bool DoencaApCirculatorio { get; set; }
        public bool Fumador { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Colesterol { get; set; }
        public double Glicose { get; set; }
        public double PAD { get; set; } // pressão arterial diastólica
        public double PAS { get; set; } // pressão arterial sistólica


        //CONSTRUTORES 
        public Rastreio()
        {

        }

        public Rastreio(Utente utente, DateTime dataConsulta)
        {
            Utente = utente;
            DataConsulta = dataConsulta;
        }

        public Rastreio(Utente utente, DateTime dataConsulta, string antecedentes, bool antiHipertensor, bool antiDislipidemicos, bool doencaCerebroVascular, bool doencaCardiaca, bool doencaApCirculatorio, bool fumador, double peso, double altura, double colesterol, double glicose, double pAD, double pAS)
        {
            Utente = utente;
            DataConsulta = dataConsulta;
            Antecedentes = antecedentes;
            AntiHipertensor = antiHipertensor;
            AntiDislipidemicos = antiDislipidemicos;
            DoencaCerebroVascular = doencaCerebroVascular;
            DoencaCardiaca = doencaCardiaca;
            DoencaApCirculatorio = doencaApCirculatorio;
            Fumador = fumador;
            Peso = peso;
            Altura = altura;
            Colesterol = colesterol;
            Glicose = glicose;
            PAD = pAD;
            PAS = pAS;
        }

        public void SetDadosRastreio()
        {
            Console.Write("Inicie o registo dos antecedentes: ");
            Antecedentes = Console.ReadLine();

            Console.Write("Anti-hipertensor (Sim/Não): ");
            AntiHipertensor = Console.ReadLine().ToLower() == "sim";

            Console.Write("Anti-dislipidêmicos (Sim/Não): ");
            AntiDislipidemicos = Console.ReadLine().ToLower() == "sim";

            Console.Write("Doença cerebro-vascular (Sim/Não): ");
            DoencaCerebroVascular = Console.ReadLine().ToLower() == "sim";

            Console.Write("Doença isquémica cardíaca (Sim/Não): ");
            DoencaCardiaca = Console.ReadLine().ToLower() == "sim";

            Console.Write("Doença aparelho circulatótio (Sim/Não): ");
            DoencaApCirculatorio = Console.ReadLine().ToLower() == "sim";

            Console.Write("Fumador (Sim/Não): ");
            Fumador = Console.ReadLine().ToLower() == "sim";


            Console.WriteLine();
            Console.WriteLine("Inicie o registe do exame físico:");

            Console.Write("Peso (kg): ");
            Peso = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Altura (m): ");
            Altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Colesterol (mg/dl): ");
            Colesterol = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Glicose (mg/dl): ");
            Glicose = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Pressão arterial (mmHg): ");
            Console.Write("Pressão arterial diastólica: ");
            PAD = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Pressão arterial sistólica: ");
            PAS = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Informações adicionadas ao rastreio com sucesso.");
            MostrarDadosRastreio();
        }
        
        public void MostrarDadosRastreio()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Dados do Rastreio:");
            sb.AppendLine($"Antecedentes: {Antecedentes}");
            sb.AppendLine($"Anti-hipertensor: {(AntiHipertensor ? "Sim" : "Não")}");
            sb.AppendLine($"Anti-dislipidêmicos: {(AntiDislipidemicos ? "Sim" : "Não")}");
            sb.AppendLine($"Doença cerebro-vascular: {(DoencaCerebroVascular ? "Sim" : "Não")}");
            sb.AppendLine($"Doença isquémica cardíaca: {(DoencaCardiaca ? "Sim" : "Não")}");
            sb.AppendLine($"Doença aparelho circulatório: {(DoencaApCirculatorio ? "Sim" : "Não")}");
            sb.AppendLine($"Fumador: {(Fumador ? "Sim" : "Não")}");
            sb.AppendLine($"Peso: {Peso.ToString("F2",CultureInfo.InvariantCulture)} kg");
            sb.AppendLine($"Altura: {Altura.ToString("F2", CultureInfo.InvariantCulture)} m");
            sb.AppendLine($"Colesterol: {Colesterol.ToString("F2", CultureInfo.InvariantCulture)} mg/dl");
            sb.AppendLine($"Glicose: {Glicose.ToString("F2", CultureInfo.InvariantCulture)} mg/dl");
            sb.AppendLine($"Pressão arterial diastólica: {PAD.ToString("F2", CultureInfo.InvariantCulture)} mmHg");
            sb.AppendLine($"Pressão arterial sistólica: {PAS.ToString("F2", CultureInfo.InvariantCulture)} mmHg");

            Console.WriteLine(sb.ToString());
        }
    }
}