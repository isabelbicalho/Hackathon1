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
            Prato prato1 = new Prato("Escondidinho de batata doce",
                "R$ 15,00", 
                new List<string>(new string[] { "azeite", "cebola", "alho", "batata doce", "leite vegetal", "peito de frango", "tomate", "queijo cottage" }),
                false, true, false, false, false, true);
            Prato prato2 = new Prato("Creme de manga", 
                "10,00", 
                new List<string>(new string[] { "manga", "biomassa de banana verde", "leite vegetal", "sementes de chia" }),
                false,false,false,false,false,false);
            Prato prato3 = new Prato("Suflê de couve-flor", "R$ 12,00",
                new List<string>(new string[] { "couve-flor", "ovo", "queijo parmesão" }),
                false,true,true,false,false,false);
            Prato prato4 = new Prato("Carne de soja", "R$ 15,00",
                new List<string>(new string[] { "proteína de soja", "água", "vinagre", "azeite", "cebola", "tomate" }),
                false, false, false, false, false, false);
            Prato prato5 = new Prato("Salpicão de frango","R$ 18,90", new List<string>(new string[] {"frango", "cenoura", "maçã verde", "salsinha", "salsão", "sal", "pimenta", "iogurte natural", "nozes picadas"}), false, false, false, false, false, true);
            Prato prato6 = new Prato("Creme de espinafre", "R$ 14,90",
                new List<string>(new string[] {"espinafre", "leite vegetal", "farinha de arroz", "cebola", "alho", "azeite", "noz moscada", "sal" }), false, false, false, false, false, false);
            Prato prato7 = new Prato("Legumes no vapor com molho de cebola", "R$ 12,90", new List<string>(new string[] { "cenoura", "chuchu", "abobrinha", "salsinha", "cebola", "limão", "azeite", "sal" }),
                false,false,false,false,false,false);
            /*Prato prato8 = new Prato("");
            Prato prato9 = new Prato("");
            Prato prato10 = new Prato("");
            Prato prato11 = new Prato("");
            Prato prato12 = new Prato("");
            Prato prato13 = new Prato("");
            Prato prato14 = new Prato("");
            Prato prato15 = new Prato("");*/
        }
    }
}
