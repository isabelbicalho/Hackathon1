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

        public Document menuInicial()
        {
            Document opcoes = new Select
            {
                Text = banco.respostas[1],
                Options = new[]
                {
                    new SelectOption
                    {
                        Order = 1,
                        Text = "Aprender receitas",
                        Value = new PlainText { Text = "Aprender receitas" }
                    },
                    new SelectOption
                    {
                        Order = 2,
                        Text = "Sugestão de restaurantes",
                        Value = new PlainText { Text = "Sugestão de restaurantes" }
                    },
                    new SelectOption
                    {
                        Order = 3,
                        Text = "Delivery",
                        Value = new PlainText { Text = "Delivery" }
                    }
                }
            };
            return opcoes;
        }

        public DocumentCollection agregarTexto (DocumentCollection resposta, string texto)
        {
            Document doc = new PlainText { Text = texto };
            Document[] newItems = new Document[resposta.Items.Length + 1];
            resposta.Items.CopyTo(newItems, 0);
            newItems[newItems.Length - 1] = doc;
            resposta.Items = newItems;
            return resposta;
        }

        public DocumentCollection agregarItem(DocumentCollection resposta, Document item)
        { 
            Document[] newItems = new Document[resposta.Items.Length + 1];
            resposta.Items.CopyTo(newItems, 0);
            newItems[newItems.Length - 1] = item;
            resposta.Items = newItems;
            return resposta;
        }

        public DocumentCollection gerarResposta(Message input)
        {
            DocumentCollection resposta = new DocumentCollection();
            if (!banco.usuarios.ContainsKey(input.From.Name))
            {
                banco.usuarios[input.From.Name] = new Usuario();
                banco.usuarios[input.From.Name].estado = 1;
                Document doc = new PlainText { Text = "Qual o seu nome?" };
                resposta = agregarItem(resposta, doc);
            }
            else if (input.Content.ToString().Contains("Sugestão de restaurantes"))
            {
                banco.usuarios[input.From.Name].estado = 3;
                resposta = agregarItem(resposta, new PlainText { Text = banco.respostas[3] });
            }
            else
            {
                switch (banco.usuarios[input.From.Name].estado)
                {
                    case 1:
                        Document opcoes = menuInicial();
                        resposta = agregarItem(resposta, opcoes);
                        break;
                    case 3:

                        break;
                }
                
            }
            return resposta;
        }
    }
}
