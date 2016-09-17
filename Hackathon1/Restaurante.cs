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

        public Restaurante (string nome, string endereco, string telefone, List<Prato> cardapio)
        {
            this.nome = nome;
            this.endereco = endereco;
            this.telefone = telefone;
            this.cardapio = cardapio;
        }
    }
}
