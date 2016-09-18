﻿using System;
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
            necessidade = 0;
            restricao = 0;
            ingrediente = "";
            prato = "";
        }
    }
    public enum Necessidade
    {
        nenhum = 0,
        receita,
        restaurante,
        delivery
    }
    public enum Restricao
    {
        nenhum = 0,
        lactose,
        gluten,
        acucar
    }
}
