using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaDeDoces
{
    class Pagamento
    {
        private int codigo;
        private string descricao;
        private double valor;
        private short FormaPagamento;
        private DateTime DataPagamento;
        private double ValorTotal;

        public Pagamento() 
        {
            codigo = 0;
            descricao = "";
            valor = 0;
            FormaPagamento = 0;
            DataPagamento = new DateTime();
            ValorTotal = 0;
        }//Fim do Metodo construtor

        public int ModificarCodigo
        { 
            get
            {
                return this.codigo;
            }// Fim do Get 

            set
            {
                this.codigo = value;
            }//Fim do Set
        }//Fim do ModificarCodigo

        public string ModificarDescricao
        {
            get
            {
                return this.descricao;
            }// Fim do Get 

            set
            {
                this.descricao = value;
            }//Fim do Set
        }//Fim do ModificarDescricao

        public double ModificarValor
        {
            get
            {
                return this.valor;
            }//Fim do Get

            set
            {
                this.valor = value;
            }//Fim do Set
        }//Fim do ModificarValor

        public short ModificarPagamento
        {
            get
            {
                return this.FormaPagamento;
            }//Fim do Get

            set
            {
                this.FormaPagamento = value;
            }// Fim do Set
        }//Fim do ModificarPagamento

        public DateTime ModificarData
        {
            get
            {
                return this.DataPagamento;
            }//Fim do Get

            set
            {
                this.DataPagamento = value;
            }// Fim do Set
        }// Fim do ModificarData

        public double ModificarValorTotal
        {
            get
            {
                return this.ValorTotal;
            }//Fim do Get

            set 
            { 
                this.ValorTotal = value; 
            }
        }// Fim do ModificarValorTotal

        public void CadastrarPagamento (int codigo, string descricao, double valor, short FormaPagamento, DateTime DataPagamento, Double ValorTotal)
        {
            ModificarCodigo = codigo;
            ModificarDescricao = descricao;
            ModificarValor = valor;
            ModificarPagamento = FormaPagamento;
            ModificarData = DataPagamento;
            ModificarValorTotal = ValorTotal;
        }

        public string ConsultarPagamento(int codigo)
        {
            string msg = "";

            if (ModificarCodigo == codigo)
            {
                msg = "\nCódigo: " + ModificarCodigo +
                      "\nDescrição: " + ModificarDescricao +
                      "\nValor: " + ModificarValorTotal +
                      "\nForma de Pagamento: " + ModificarPagamento +
                      "\nData de Pagamento: " + ModificarData;
            }
            else
            {
                msg = "O Codigo de Pagamento não Existe";
            }
            return msg;
        }

        public double VerificarTroco(int codigo)
        {
            double troco = 0;

            if (ModificarCodigo == codigo)
            {
                if (ModificarPagamento == 2)
                {
                    troco = (ModificarValorTotal - ModificarValor);
                }
                else
                {
                    troco = 0;
                }
            }
            return troco; //Return SEMPRE FORA DOS ifs 
        }
        
        public string EfetuarPagamento(int codigo)
        {
            string msg = "";

            if (ModificarCodigo == codigo)
            {
                if(ModificarValorTotal > ModificarValor)
                {
                    msg = "Erro!, Valor de Pagamento insuficiente";
                }
                else
                {
                    msg = "Pagamento Realizado!!";
                    double troco = VerificarTroco(codigo); //É preciso uma variavel para armazenar o resultado do VerificarTroco
                }
            }
            return msg;
        }

        public void MetodoPagamento(int codigo)
        {
            if (ModificarCodigo == codigo)
            { 
                if ()
            }

        }

    }// Fim da Classe

}
