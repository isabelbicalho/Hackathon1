using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Banco
    {
        //public Dictionary<string,Usuario> usuarios = new Dictionary<string, Usuario>();
        public List<Restaurante> restaurantes = new List<Restaurante>();
        //public List<string> usuarioSaudacao = new List<string>();

        public Dictionary<int, String> respostas = new Dictionary<int, string>()
        {
            {101, "Como posso te ajudar?"},
            {102, "Gostaria de comer no local ou receber em casa?" },
            {103, "Algum prato específico? (salmão, frango, caldo, sopa, ...)" },
            {104, "Encontrei ótimos restaurantes para você! Qual deles gostaria de ver o cardápio?" },
            {105, "Não encontrei nenhum restaurante com esse prato :( Algum outro prato específico?" },
            {106, "Gostaria do endereço do estabelecimento?" },
            {107, "Deseja visualizar outro estabelecimento?" },
            {108, "Posso te ajudar com mais alguma coisa?" },
            {109, "Em qual cidade você mora?" },
            {110, "Gostaria de visualizar mais algum cardápio? Se sim, qual?" }
        };

        public void adicionarRestaurante(Restaurante restaurante)
        {
            restaurantes.Add(restaurante);
        }

    }
}
