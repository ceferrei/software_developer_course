using System;

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
