using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Receita
    {
        public string nome;
        public List<string> ingredientes = new List<string>();
        public string link;
        public bool gluten;
        public bool leite;
        public bool acucar;

        public Receita(string nome, List<string> ingredientes, string link, bool gluten, bool leite, bool acucar)
        {
            this.nome = nome;
            this.ingredientes = ingredientes;
            this.link = link;
            this.gluten = gluten;
            this.leite = leite;
            this.acucar = acucar;
        }
    }
}