using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Usuario
    {
        public string id;
        public string nome;
        public int estado = 0;
        //pedido atual
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
            necessidade = Necessidade.nenhum.GetHashCode();
            restricao = Restricao.nenhum.GetHashCode();
            ingrediente = "";
            prato = "";
        }
    }
    public enum Necessidade
    {
        nenhum,
        receita,
        restaurante,
        delivery
    }
    public enum Restricao
    {
        nenhum,
        lactose,
        gluten,
        acucar
    }
}
