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
        public List<string> usuarioSaudacao = new List<string>();
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
    }
}
