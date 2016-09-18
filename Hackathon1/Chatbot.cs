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
                Text = banco.respostas[101],
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

        public Document gerarResposta(Message input)
        {
            string mensagemUsuario = input.Content.ToString();

            if (!banco.usuarios.ContainsKey(input.From.Name))
            {
                banco.usuarios[input.From.Name] = new Usuario();
                banco.usuarios[input.From.Name].estado = 112;
                Document doc = new PlainText { Text = "Qual o seu nome?" };
                return doc;
            }
            else
            {
                switch (banco.usuarios[input.From.Name].estado)
                {
                    case 112:
                        // obter nome do usuario
                        banco.usuarios[input.From.Name].nome = mensagemUsuario;
                        // Você restringe ao consumo do leite, açúcar ou glúten?
                        banco.usuarios[input.From.Name].estado = 113;
                        return new PlainText { Text = banco.respostas[112] };
                    case 113:
                        if (mensagemUsuario.Contains("Não"))
                        {
                            banco.usuarios[input.From.Name].estado = 101;
                            goto case 101;
                        }
                        else
                        {
                            // atualizar usuario
                            banco.usuarios[input.From.Name].estado = 101;
                            goto case 101;
                        }
                    case 101:
                        // Como posso te ajudar?
                        if (mensagemUsuario.Contains("Sugestão de restaurantes"))
                        {
                            banco.usuarios[input.From.Name].estado = 103;
                            return new PlainText { Text = banco.respostas[103] };
                        }
                        if (mensagemUsuario.Contains("Aprender receitas"))
                        {
                            // Inserir o estado para a primeira mensagem para as receitas
                            return null;
                        }
                        if (mensagemUsuario.Contains("Delivery"))
                        {
                            // Inserir o estado para a primeira mensagem para delivery
                            return null;
                        }
                        Document opcoes = menuInicial();
                        return opcoes;
                    case 103:
                    case 105:
                        // Algum prato específico? (salmão, frango, caldo, sopa, ...)
                        // Chamar a função para pesquisar os pratos aqui
                        if (mensagemUsuario.Contains("Não"))
                        {
                            // pesquisar apenas pelas restrições
                        }
                        else
                        {
                            // pesquisar por restrições e preferências
                        }
                        // Se encontrou
                        banco.usuarios[input.From.Name].estado = 104;
                        return null; // Retorna Select dos restaurantes
                        // Se nao encontrou
                        banco.usuarios[input.From.Name].estado = 105;
                        return new PlainText { Text = banco.respostas[105] };
                    case 104:
                    case 110:
                        // Encontrei ótimos restaurantes para você! Qual deles gostaria de ver o cardápio?
                        if (mensagemUsuario.Contains("Não"))
                        {
                            // Perguntar se pode ajudar com mais algo
                            banco.usuarios[input.From.Name].estado = 108;
                            return new PlainText { Text = banco.respostas[108] };
                        }
                        else
                        {
                            // Pesquisar a mensagem de input (restaurante) nos fornecedores 
                            // e retornar o cardápio.
                            // Perguntar se o cliente quer o endereço do estabelecimento no
                            // próprio campo text do Select (estado 106)
                            banco.usuarios[input.From.Name].estado = 106;
                            return null;
                        }
                    case 106:
                        // Gostaria do endereço do estabelecimento?
                        if (mensagemUsuario.Contains("Sim"))
                        {
                            // Retornar mensagem de texto com o endereço do estabelecimento.
                            // Perguntar se pode ajudar com mais alguma coisa
                            return null;
                        }
                        if (mensagemUsuario.Contains("Não"))
                        {
                            // Perguntar se quer ver outro estabelecimento
                            banco.usuarios[input.From.Name].estado = 110;
                            // Gostaria de visualizar mais algum cardápio? Se sim, qual?
                            return new PlainText { Text = banco.respostas[110] };
                        }
                        return new PlainText { Text = "default" };
                    case 108:
                        // Posso te ajudar com mais alguma coisa?
                        if (mensagemUsuario.Contains("Sim"))
                        {
                            // Voltar para o início
                            banco.usuarios[input.From.Name].estado = 101;
                            return new PlainText { Text = banco.respostas[101] };
                        }
                        if (mensagemUsuario.Contains("Não"))
                        {
                            // Tudo bem :)
                            banco.usuarios[input.From.Name].estado = 0;
                            return new PlainText { Text = banco.respostas[111] };
                        }
                        return new PlainText { Text = "default" };
                    default:
                        return new PlainText { Text = "default" };

                }
                
            }
        }
    }
}
