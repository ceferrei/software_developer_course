using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardappio.Entities
{
    internal class ExameFisico
    {
        public int NumUtente { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Colesterol { get; set; }
        public double Glicose { get; set; }
        public double PressaoArterial { get; set; }

        public ExameFisico()
        {
        }

        public ExameFisico(int numUtente, double peso, double altura, double colesterol, double glicose, double pressaoArterial)
        {
            NumUtente = numUtente;
            Peso = peso;
            Altura = altura;
            Colesterol = colesterol;
            Glicose = glicose;
            PressaoArterial = pressaoArterial;
        }

        public void AdicionarExameFisico(double peso, double altura, double colesterol, double glicose, double pressaoArterial)
        {
            Peso = peso;
            Altura = altura;
            Colesterol = colesterol;
            Glicose = glicose;
            PressaoArterial = pressaoArterial;
        }

        public void EditarExameFisico(double novoPeso, double novaAltura, double novoColesterol, double novaGlicose, double novaPressaoArterial)
        {
            Peso = novoPeso;
            Altura = novaAltura;
            Colesterol = novoColesterol;
            Glicose = novaGlicose;
            PressaoArterial = novaPressaoArterial;
        }
    }
}

