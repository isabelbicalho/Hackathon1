using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Povoador
    {
        public static void povoar (Banco banco)
        {
            Restaurante restaurante1 = new Restaurante("Viva Alimentos", "Pc. Arcangelo Maleta 8", "30360-532");
            restaurante1.adicionarPrato(new Prato("Escondidinho de batata doce", "R$ 15,00", 
                new List<string>(new string[] { "azeite", "cebola", "alho", "batata doce", "leite vegetal", "peito de frango", "tomate", "queijo cottage" }),
                false, true, false, false, false, true));
            restaurante1.adicionarPrato(new Prato("Creme de manga", "R$10,00", 
                new List<string>(new string[] { "manga", "biomassa de banana verde", "leite vegetal", "sementes de chia" }),
                false,false,false,false,false,false));
            restaurante1.adicionarPrato(new Prato("Suflê de couve-flor", "R$ 12,00",
                new List<string>(new string[] { "couve-flor", "ovo", "queijo parmesão" }),
                false,true,true,false,false,false));
            restaurante1.adicionarPrato(new Prato("Gaspacho (sopa)", "R$ 24,90",
                new List<string>(new string[] { "tomate", "cebola", "pepino", "pimentao vermelho", "pimentao verde", "pimenta do reino", "pao integral" }),
                true, false, false));
            banco.adicionarRestaurante(restaurante1);

            Restaurante restaurante2 = new Restaurante("Lev", "Rua Fernandes Tourinho 350", "30112-000");
            restaurante2.adicionarPrato(new Prato("Carne de soja", "R$ 15,00",
                new List<string>(new string[] { "proteína de soja", "água", "vinagre", "azeite", "cebola", "tomate" }),
                false, false, false, false, false, false));
            restaurante2.adicionarPrato(new Prato("Salpicão de frango","R$ 18,90",
                new List<string>(new string[] {"frango", "cenoura", "maçã verde", "salsinha", "salsão", "sal", "pimenta", "iogurte natural", "nozes picadas"}),
                false, false, false, false, false, true));
            restaurante2.adicionarPrato(new Prato("Creme de espinafre", "R$ 14,90",
                new List<string>(new string[] {"espinafre", "leite vegetal", "farinha de arroz", "cebola", "alho", "azeite", "noz moscada", "sal" }),
                false, false, false, false, false, false));
            banco.adicionarRestaurante(restaurante2);

            Restaurante restaurante3 = new Restaurante("Bem Natural", "Rua Alagoas 911", "30130-160");
            restaurante3.adicionarPrato(new Prato("Legumes no vapor com molho de cebola", "R$ 12,90",
                new List<string>(new string[] { "cenoura", "chuchu", "abobrinha", "salsinha", "cebola", "limão", "azeite", "sal" }),
                false,false,false,false,false,false));
            restaurante3.adicionarPrato(new Prato("Bolo salgado vegetariano", "R$ 9,90",
                new List<string>(new string[] { "tomate", "cebola", "ervilha", "milho", "azeitona", "quinoa", "sal", "pimenta", "manjericão" }),
                true, true, false));
            restaurante3.adicionarPrato(new Prato("Quiche de palmito", "R$ 19,90",
                new List<string>(new string[] { "sementes de chia", "oleo de coco", "palmito", "ervilha", "tomate" }),
                false, false, false));
            restaurante3.adicionarPrato(new Prato("Papinha de cenoura com chuchu e carne", "R$ 4,90",
                new List<string>(new string[] { "carne moida", "cenoura", "chuchu", "couve", "mandioca" }),
                false, false, false));
            banco.adicionarRestaurante(restaurante3);

            Restaurante restaurante4 = new Restaurante("Tudo verde", "Rua Claudio Pinheiro de Lima 39", "30870-020");
            restaurante4.adicionarPrato(new Prato("Muffin de maçã light", "R$ 4,90",
                new List<string>(new string[] { "açucar", "leite", "canela", "ovo", "farinha de trigo", "fermento" }),
                true, true, true));
            banco.adicionarRestaurante(restaurante4);

            Restaurante restaurante5 = new Restaurante("Mundo Verde", "Rua Curitiba 1982", "30170-122");
            restaurante5.adicionarPrato(new Prato("Quiche de palmito", "R$ 19,90",
                new List<string>(new string[] { "sementes de chia", "oleo de coco", "palmito", "ervilha", "tomate" }),
                false, false, false));
            restaurante5.adicionarPrato(new Prato("Arroz a grega", "R$ 9,90",
                new List<string>(new string[] { "gengibre", "arroz", "ervilha", "milho verde", "queijo branco", "manteiga ghee" }),
                true, false, false));
            restaurante5.adicionarPrato(new Prato("Pave de chocolate fit", "R$ 18,50",
                new List<string>(new string[] { "tamara", "castanha de caju", "banana verde", "leite de coco", "morango", "chocolate amargo", "sementes de chia" }),
                false, false, true));
            restaurante5.adicionarPrato(new Prato("Mousse de alfarroba", "R$ 24,90",
                new List<string>(new string[] { "chocolate 70% cacau", "creme de soja", "alfarroba em pó", "ovo", "cereja" }),
                false, false, false));
            banco.adicionarRestaurante(restaurante5);
        }
    }
}
