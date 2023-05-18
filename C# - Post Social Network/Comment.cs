using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_Social_Network
{
    internal class Comment
    {
        public string Text { get; set; }
       

        //Construtores
        public Comment() { } // ctor- atalho

        public Comment(string text)
        {
            Text = text;
        }
    }
}
