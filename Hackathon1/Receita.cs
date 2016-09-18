using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Receita
    {
        private string nome;
        private List<string> ingredientes = new List<string>();
        private string link;

        public Receita(string nome, List<string> ingredientes, string link)
        {
            this.nome = nome;
            this.ingredientes = ingredientes;
            this.link = link;
        }
    }
}