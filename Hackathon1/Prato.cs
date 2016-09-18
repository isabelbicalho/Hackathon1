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
        public bool ovo;
        public bool crustaceo;
        public bool acucar;
        public bool carne;

        public Prato (string nome, string preco, List<string> ingredientes,
            bool gluten,
            bool leite,
            bool ovo,
            bool crustaceo,
            bool acucar,
            bool carne)
        {
            this.nome = nome;
            this.ingredientes = ingredientes;
            this.preco = preco;
            this.gluten = gluten;
            this.leite = leite;
            this.ovo = ovo;
            this.crustaceo = crustaceo;
            this.acucar = acucar;
            this.carne = carne;
        }

        List<string> buscarIngrediente(string texto)
        {
            List<string> lst = new List<string>();

            foreach (string i in lst)
            {
                if (i.Contains(texto))
                {
                    lst.Add(i);
                }
            }

            return lst;
        }
    }
}
