using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Banco
    {
        public Dictionary<string,Usuario> usuarios = new Dictionary<string, Usuario>();
        public List<Restaurante> restaurantes = new List<Restaurante>();
        //public List<string> usuarioSaudacao = new List<string>();

        public Dictionary<int, String> respostas = new Dictionary<int, string>()
        {
            {1, "Como posso te ajudar?"},
            {2, "Gostaria de comer no local ou receber em casa?" },
            {3, "Algum prato específico? (salmão, frango, caldo, sopa, ...)" },
            {4, "Encontrei esses restaurantes, gostaria de ver os cardápios?" },
            {5, "Não encontrei nenhum restaurante com esse prato :( Algum outro prato específico?" },
            {6, "Gostaria do endereço do estabelecimento?" },
            {7, "Deseja visualizar outro estabelecimento?" },
            {8, "Posso te ajudar com mais alguma coisa?" },
            {9, "Em qual cidade você mora?" }
        };

        public void adicionarRestaurante(Restaurante restaurante)
        {
            restaurantes.Add(restaurante);
        }

        public List<Restaurante> buscarRestaurante(string nome, string endereco, string pratoingrediente, bool restricaoGluten, bool restricaoLeite, bool restricaoAcucar)
        {
            List<Restaurante> lst = new List<Restaurante>();

            foreach(Restaurante r in restaurantes)
            {
                if ((String.IsNullOrEmpty(nome) || r.nome.Contains(nome)) && (String.IsNullOrEmpty(endereco) || r.endereco.Contains(endereco)) &&
                    r.buscarCardapio(pratoingrediente, restricaoGluten, restricaoLeite, restricaoAcucar).Count()>0)
                {
                    lst.Add(r);
                }
            }

            return lst;
        }

        public List<Prato> buscarCardapio(string pratoingrediente, bool restricaoGluten, bool restricaoLeite, bool restricaoAcucar)
        {
            List<Prato> lst = new List<Prato>();
            List<Prato> aux = new List<Prato>();

            foreach (Restaurante r in restaurantes)
            {
                aux = r.buscarCardapio(pratoingrediente, restricaoGluten, restricaoLeite, restricaoAcucar);
                if (aux.Count()>0)
                {
                    lst.AddRange(aux);
                }
            }

            return lst;
        }

    }
}
