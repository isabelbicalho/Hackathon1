using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Usuario
    {
        public string nome;
        public int estado = 0;
        public bool restricaoLeite = false;
        public bool restricaoGluten = false;
        public bool restricaoAcucar = false;
        //pedido atual
        public Restaurante restaurante;
        public string endereco;
        public string cidade;
        public string bairro;
        public int necessidade = 0;
        public int restricao = 0;
        public string ingrediente;
        public string prato;

        public void iniciarPedido()
        {
            endereco = "";
            cidade = "";
            bairro = "";
            necessidade = 0;
            restricao = 0;
            ingrediente = "";
            prato = "";
        }
    }
    public enum Necessidade
    {
        receita,
        restaurante,
        delivery
    }
    public enum Restricao
    {
        lactose,
        gluten,
        acucar,
        nenhum
    }
}
