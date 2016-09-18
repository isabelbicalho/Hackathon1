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

            foreach (Prato p in cardapio)
            {
                if ((!restricaoGluten || p.gluten) && (!restricaoLeite || p.leite) && (!restricaoAcucar || p.acucar) &&
                    (string.IsNullOrEmpty(pratoingrediente) || p.nome.Contains(pratoingrediente) || p.ingredientes.Contains(pratoingrediente)))
                {
                    lst.Add(p);
                }
            }

            return lst;
        }

    }
}
