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
        public List<Receita> receitas = new List<Receita>();
        //public List<string> usuarioSaudacao = new List<string>();

        public Dictionary<int, String> respostas = new Dictionary<int, string>()
        {
            {101, "Como posso te ajudar?"},
            {102, "Em qual cidade você se encontra?" },
            {103, "Algum prato específico? (salmão, frango, caldo, sopa, ...)" },
            {104, "Encontrei ótimos restaurantes para você! Qual deles gostaria de ver o cardápio?" },
            {105, "Não encontrei nenhum restaurante com esse prato :( Algum outro prato específico?" },
            {106, "Gostaria do endereço do estabelecimento?" },
            {107, "Deseja visualizar outro estabelecimento?" },
            {108, "Posso te ajudar com mais alguma coisa?" },
            {109, "Em qual cidade você mora?" },
            {110, "Gostaria de visualizar mais algum cardápio? Se sim, qual?" },
            {111, "Tudo bem :)" },
            {112, "Tem alguma restrição ao consumo do leite, açúcar ou glúten?" }
        };

        public void adicionarRestaurante(Restaurante restaurante)
        {
            restaurantes.Add(restaurante);
        }

        public List<Restaurante> buscarRestaurante(string nome, string endereco, string pratoingrediente, bool restricaoGluten, bool restricaoLeite, bool restricaoAcucar)
        {
            List<Restaurante> lst = new List<Restaurante>();

            foreach (Restaurante r in restaurantes)
            {
                if ((String.IsNullOrEmpty(nome) || r.nome.IndexOf(nome) >= 0) && (String.IsNullOrEmpty(endereco) || r.endereco.IndexOf(endereco) >= 0) &&
                    r.buscarCardapio(pratoingrediente, restricaoGluten, restricaoLeite, restricaoAcucar).Count() > 0)
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
            pratoingrediente = pratoingrediente.ToUpper();

            foreach (Restaurante r in restaurantes)
            {
                aux = r.buscarCardapio(pratoingrediente, restricaoGluten, restricaoLeite, restricaoAcucar);
                if (aux.Count() > 0)
                {
                    lst.AddRange(aux);
                }
            }

            return lst;
        }

        public void adicionarReceita(Receita receita)
        {
            receitas.Add(receita);
        }

    }

}
