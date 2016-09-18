using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Restaurante
    {
        public string nome;
        public string endereco;
        public string telefone;
        public List<Prato> cardapio = new List<Prato>();

        public Restaurante(string nome, string endereco, string telefone)
        {
            this.nome = nome;
            this.endereco = endereco;
            this.telefone = telefone;
        }

        public Restaurante(string nome, string endereco, string telefone, List<Prato> cardapio)
        {
            this.nome = nome;
            this.endereco = endereco;
            this.telefone = telefone;
            this.cardapio = cardapio;
        }

        public string cardapioToString()
        {
            string s = nome + "\n";
            //string nc = "";
            for (int i = 0; i < cardapio.Count; i++)
            {
                Prato prato = cardapio.ElementAt<Prato>(i);
                s += prato.nome + " - " + prato.preco + "\n";
                /*if (!prato.leite) nc += "leite ";
                if (!prato.gluten) nc += "glúten ";
                if (!prato.acucar) nc += "açúcar";
                if (nc.Length > 0) s += "Não contém: " + nc;*/
                //s += "\nPreço: " + prato.preco + "\n";
                //nc = "";
            }
            return s;
        }

        public void adicionarPrato(Prato prato)
        {
            cardapio.Add(prato);
        }

        public List<Prato> buscarCardapio(string pratoingrediente)
        {
            return buscarCardapio(pratoingrediente, false, false, false);
        }

        public List<Prato> buscarCardapio(string pratoingrediente, bool restricaoGluten, bool restricaoLeite, bool restricaoAcucar)
        {
            List<Prato> lst = new List<Prato>();
            pratoingrediente = pratoingrediente.ToUpper();

            foreach (Prato p in cardapio)
            {
                if ((!restricaoGluten || !p.gluten) && (!restricaoLeite || !p.leite) && (!restricaoAcucar || !p.acucar) )
                {
                    if ((string.IsNullOrEmpty(pratoingrediente) || p.nome.ToUpper().IndexOf(pratoingrediente) >= 0 || p.buscarIngrediente(pratoingrediente).Count() > 0))
                    {
                        lst.Add(p);
                    }
                }   
            }

            return lst;
        }

    }
}
