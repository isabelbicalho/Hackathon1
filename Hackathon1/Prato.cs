using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Prato
    {
        public string nome;
        public List<string> ingredientes;
        public string preco;
        public bool gluten;
        public bool leite;
        public bool acucar;

        public Prato (string nome, string preco, List<string> ingredientes,
            bool gluten,
            bool leite,
            bool acucar
)
        {
            this.nome = nome;
            this.ingredientes = ingredientes;
            this.preco = preco;
            this.gluten = gluten;
            this.leite = leite;
            this.acucar = acucar;
        }

        public List<string> buscarIngrediente(string texto)
        {
            List<string> lst = new List<string>();
            texto = texto.ToUpper();

            foreach (string i in lst)
            {
                if (i.ToUpper().IndexOf(texto) >= 0)
                {
                    lst.Add(i);
                }
            }

            return lst;
        }
    }
}
