using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Contract
{
    /*Esta classe representa um departamento*/
    internal class Department
    {
        public string NameDep { get; set; }

        /*Criamos um construtor para receber o nome do departamento*/
        public Department(string nameDep)
        {
            NameDep = nameDep;
        }
    }
}
