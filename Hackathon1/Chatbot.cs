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
        string[] saudacoes = { "Olá" };
        string[] despedidas = { "Obrigado pela preferência!" };

        public Chatbot(Banco banco)
        {
            this.banco = banco;
        }

        public bool contains (string s1, string s2)
        {
            return s2.ToUpper().IndexOf(s1.ToUpper()) >= 0;
        }

        public Restaurante buscarRestaurante (string texto)
        {
            for (int i = 0; i < banco.restaurantes.Count; i++)
            {
                if (contains(banco.restaurantes.ElementAt<Restaurante>(i).nome, texto))
                    return banco.restaurantes.ElementAt<Restaurante>(i);
            }
            return null;
        }

        public List<Restaurante> buscarRestaurantesCardapio (string texto, string numUsuario)
        {
            Usuario usuario = banco.usuarios[numUsuario];
            /*List<Restaurante> restaurantes = new List<Restaurante>();
            restaurantes = banco.buscarRestaurante("", usuario.cidade, texto, usuario.restricaoGluten, usuario.restricaoLeite, usuario.restricaoAcucar);
            for (int i = 0; i < banco.restaurantes.Count; i++)
            {
                List<Prato> cardapio = banco.restaurantes[i].buscarCardapio(texto, usuario.restricaoGluten, 
                    usuario.restricaoLeite, usuario.restricaoAcucar);
                if (cardapio.Count > 0)
                    restaurantes.Add((Restaurante)banco.restaurantes[i]);
            }*/
            return banco.buscarRestaurante("", usuario.cidade, contains("Não",texto)?"":contains("Nao", texto)?"":texto, usuario.restricaoGluten, usuario.restricaoLeite, usuario.restricaoAcucar);
        }

        public Document selectRestaurantes (List<Restaurante> restaurantes)
        {
            List<SelectOption> options = new List<SelectOption>();
            for (int i = 0; i < restaurantes.Count; i++)
            {
                SelectOption option = new SelectOption();
                option.Order = i + 1;
                option.Text = restaurantes.ElementAt<Restaurante>(i).nome;
                option.Value = new PlainText { Text = restaurantes.ElementAt<Restaurante>(i).nome };
                options.Add((SelectOption)option);
            }
            SelectOption optNenhum = new SelectOption();
            optNenhum.Order = options.Count;
            optNenhum.Text = "Nenhum";
            optNenhum.Value = new PlainText { Text = "Nenhum" };
            options.Add((SelectOption)optNenhum);
            Document select = new Select
            {
                Text = banco.respostas[104],
                Options = options.ToArray()
            };
            
            return select;
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
                        Text = "Restaurantes/Lojas",
                        Value = new PlainText { Text = "Restaurantes/Lojas" }
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
                        // Tem alguma restrição ao consumo do leite, do açúcar ou do glúten?
                        banco.usuarios[input.From.Name].estado = 113;
                        return new PlainText { Text = banco.respostas[112] };
                    case 113:
                        if (contains("Não", mensagemUsuario) || contains("Nao", mensagemUsuario))
                        {
                            banco.usuarios[input.From.Name].estado = 101;
                            goto case 101;
                        }
                        bool ehIntolerante = false;
                        if (contains("leite", mensagemUsuario) || contains("lactose", mensagemUsuario))
                        {
                            banco.usuarios[input.From.Name].restricaoLeite = true;
                            ehIntolerante = true;
                        }
                        if (contains("açúcar", mensagemUsuario) || contains("açucar", mensagemUsuario) ||
                            contains("acúcar", mensagemUsuario) || contains("acucar", mensagemUsuario))
                        {
                            banco.usuarios[input.From.Name].restricaoAcucar = true;
                            ehIntolerante = true;
                        }
                        if (contains("glúten", mensagemUsuario) || contains("gluten", mensagemUsuario))
                        {
                            banco.usuarios[input.From.Name].restricaoGluten = true;
                            ehIntolerante = true;
                        }
                        if (ehIntolerante)
                        { 
                            banco.usuarios[input.From.Name].estado = 101;
                            goto case 101;
                        }
                        else if (contains("Sim", mensagemUsuario))
                        {
                            banco.usuarios[input.From.Name].estado = 114;
                            return new PlainText { Text = "Quais?" };
                        }
                        else
                        {
                            return new PlainText { Text = "default" };
                        }
                    case 114:
                        if (contains("leite", mensagemUsuario) || contains("lactose", mensagemUsuario))
                            banco.usuarios[input.From.Name].restricaoLeite = true;
                        if (contains("açúcar", mensagemUsuario) || contains("açucar", mensagemUsuario) ||
                            contains("acúcar", mensagemUsuario) || contains("acucar", mensagemUsuario))
                            banco.usuarios[input.From.Name].restricaoAcucar = true;
                        if (contains("glúten", mensagemUsuario) || contains("gluten", mensagemUsuario))
                            banco.usuarios[input.From.Name].restricaoGluten = true;
                        banco.usuarios[input.From.Name].estado = 101;
                        goto case 101;
                    case 101:
                        // Como posso te ajudar?
                        if (contains("Restaurantes/Lojas", mensagemUsuario))
                        {
                            banco.usuarios[input.From.Name].estado = 102;
                            return new PlainText { Text = banco.respostas[102] };
                        }
                        if (contains("Aprender receitas", mensagemUsuario))
                        {
                            // Inserir o estado para a primeira mensagem para as receitas
                            return null;
                        }
                        if (contains("Delivery", mensagemUsuario))
                        {
                            // Inserir o estado para a primeira mensagem para delivery
                            return null;
                        }
                        Document opcoes = menuInicial();
                        return opcoes;
                    case 102:
                        // Em qual cidade você se encontra?
                        banco.usuarios[input.From.Name].cidade = mensagemUsuario;
                        banco.usuarios[input.From.Name].estado = 103;
                        return new PlainText { Text = banco.respostas[103] };
                    case 103:
                    case 105:
                        // Algum prato específico? (salmão, frango, caldo, sopa, ...)
                        // Chamar a função para pesquisar os pratos aqui

                        if (contains("Não", mensagemUsuario) || contains("Nao", mensagemUsuario))
                        {
                            // pesquisar apenas pelas restrições
                        }
                        else
                        {
                            // pesquisar por restrições e preferências
                            /*if (contains("leite", mensagemUsuario))
                                banco.usuarios[input.From.Name].restricaoLeite = true;
                            if (contains("glúten", mensagemUsuario))
                                banco.usuarios[input.From.Name].restricaoGluten = true;
                            if (contains("açúcar", mensagemUsuario))
                                banco.usuarios[input.From.Name].restricaoAcucar = true;*/
                        }
                        List<Restaurante> restaurantes = buscarRestaurantesCardapio(mensagemUsuario, input.From.Name);
                        // Se encontrou
                        if (restaurantes.Count > 0)
                        {
                            banco.usuarios[input.From.Name].estado = 104;
                            return selectRestaurantes(restaurantes);
                        }
                        // Se nao encontrou
                        banco.usuarios[input.From.Name].estado = 105;
                        return new PlainText { Text = banco.respostas[105] };
                    case 104:
                    case 110:
                        // Encontrei ótimos restaurantes para você! Qual deles gostaria de ver o cardápio?
                        if (contains("Nenhum", mensagemUsuario))
                        {
                            // Perguntar se pode ajudar com mais algo
                            banco.usuarios[input.From.Name].estado = 108;
                            return new PlainText { Text = banco.respostas[108] };
                        }
                        else
                        {
                            // Pesquisar a mensagem de input (restaurante) nos fornecedores 
                            // e retornar o cardápio do restaurante que a pessoa escolheu.
                            // Perguntar se o cliente quer o endereço do estabelecimento no
                            // próprio campo text do Select (estado 106)
                            
                            // Obter fornecedor através da mensagem de texto
                            Restaurante restaurante = buscarRestaurante(mensagemUsuario);
                            if (restaurante != null)
                            {
                                banco.usuarios[input.From.Name].estado = 106;
                                banco.usuarios[input.From.Name].restaurante = restaurante;
                                return new PlainText { Text = restaurante.cardapioToString() + "\n" + banco.respostas[106] };
                            }
                            return new PlainText { Text = "default" };
                        }
                    case 106:
                        // Gostaria do endereço do estabelecimento?
                        if (contains("Sim", mensagemUsuario))
                        {
                            // Retornar mensagem de texto com o endereço do estabelecimento.
                            // Perguntar se pode ajudar com mais alguma coisa
                            banco.usuarios[input.From.Name].estado = 108;
                            Restaurante restaurante = banco.usuarios[input.From.Name].restaurante;
                            return new PlainText { Text = "Segue o endereço do estabelecimento: \n" + restaurante.nome + ": " + restaurante.endereco + "\n"+banco.respostas[108] };
                        }
                        if (contains("Não", mensagemUsuario) || contains("Nao", mensagemUsuario))
                        {
                            // Perguntar se quer ver outro estabelecimento
                            banco.usuarios[input.From.Name].estado = 110;
                            // Gostaria de visualizar mais algum cardápio? Se sim, qual?
                            return new PlainText { Text = banco.respostas[110] };
                        }
                        return new PlainText { Text = "default" };
                    case 108:
                        // Posso te ajudar com mais alguma coisa?
                        if (contains("Sim", mensagemUsuario))
                        {
                            // Voltar para o início
                            banco.usuarios[input.From.Name].estado = 101;
                            return new PlainText { Text = banco.respostas[101] };
                        }
                        if (contains("Não", mensagemUsuario) || contains("Nao", mensagemUsuario))
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
