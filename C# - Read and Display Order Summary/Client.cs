using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_and_Display_Order_Summary
{
    internal class Client
    {
        public string NameClient { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        //Construtores
        public Client() { }

        public Client(string name, string email, DateTime birthDate)
        {
            NameClient = name;
            Email = email;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return NameClient + "(" + BirthDate.ToString("dd/MM/yyyy") + ") - " + Email;
        }
    }
}