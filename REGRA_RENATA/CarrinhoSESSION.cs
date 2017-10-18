using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REGRA_RENATA
{
    public class CarrinhoSESSION
    {
        public CarrinhoSESSION(int id, string nome, double vl, int qtd, string path)
        {
            IdCarrinho = id;
            valor = vl;
            this.nome = nome;
            quantidade = qtd;
            caminho = path;
        }

        public int IdCarrinho
        {
            get;
            set;
        }

        public double valor
        {
            get;
            set;
        }

         public int quantidade
        {
            get;
            set;
        }

        public String caminho
        {
            get;
            set;
        }

        public String nome
        {
            get;
            set;
        }


    }
}