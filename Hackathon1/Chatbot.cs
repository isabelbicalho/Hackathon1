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
        public Banco banco;
        string[] saudacoes = { "Olá!" };
        string[] despedidas = { "Obrigado pela preferência!" };

        public Chatbot(Banco banco)
        {
            this.banco = banco;
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
            List<Document> newItems = new List<Document>();
            Document[] temp = resposta.Items;
            if (temp != null)
            {
                resposta.Items = newItems.ToArray();
                for (int i = 0; i < temp.Length; i++)
                {
                    newItems.Add((Document)temp[i]);
                }
            }
            newItems.Add((Document)item);
            resposta.Items = newItems.ToArray();
            return resposta;
        }

        public Document gerarResposta(Message input)
        {
            if (!banco.usuarios.ContainsKey(input.From.Name))
            {
                banco.usuarios[input.From.Name] = new Usuario();
                banco.usuarios[input.From.Name].estado = 1;
                Document doc = new PlainText { Text = "Qual o seu nome?" };
                //resposta = agregarItem(resposta, doc);
                return doc;
            }
            else if (input.Content.ToString().Contains("Sugestão de restaurantes"))
            {
                banco.usuarios[input.From.Name].estado = 3;
                return new PlainText { Text = banco.respostas[3] };
            }
            else
            {
                switch (banco.usuarios[input.From.Name].estado)
                {
                    case 1:
                        Document opcoes = menuInicial();
                        return opcoes;
                    case 3:

                        break;
                }
                
            }
            return null;
        }
    }
}
