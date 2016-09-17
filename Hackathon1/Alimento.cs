using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Alimento
    {
        private string nome;
        private string descricao;
        private string preco;

        public Alimento (string nome, string descricao, string preco)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.preco = preco;
        }
    }
}
