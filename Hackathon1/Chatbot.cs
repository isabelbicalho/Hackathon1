using Lime.Messaging.Contents;
using Lime.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Chatbot
    {
        Banco banco;
        string[] saudacoes = { "Olá!" };
        string[] despedidas = { "Obrigado pela preferência!" };

        public Chatbot(Banco banco)
        {
            this.banco = banco;
        }

        public string isSaudacao(string input)
        {
            List<string> usuarioSaudacao = banco.usuarioSaudacao;
            if (usuarioSaudacao.Contains(input))
            {
                var document = new Select
                {
                    Text = "O que você deseja?",
                    Options = new[]
                    {
                        new SelectOption
                        {
                            Order = 1,
                            Text = "Buscar restaurantes de comida saudável",
                            Value = new PlainText { Text = "1" }
                        },
                        new SelectOption
                        {
                            Order = 2,
                            Text = "Buscar fornecedores de comida saudável",
                            Value = new PlainText { Text = "2" }
                        },
                        new SelectOption
                        {
                            Order = 3,
                            Text = "Sugestões de receitas",
                            Value = new PlainText { Text = "3" }
                        }
                    }
                };
            }
            return null;
        }

        public void gerarResposta(Message input)
        {
            if (!banco.usuarios.ContainsKey(input.from))
            {

            }
        }
    }
}
