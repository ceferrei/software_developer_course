using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Contracts.Entities
{
    internal class Department
    {
        //Propriedade de Department
        public string NameDept { get; set; }

        //Construtores
        public Department() { }

        //Este construtor recebe por parâmetro um argumento "name"
        public Department(string nameDept)
        {
            NameDept = nameDept;
        }

    }
}
