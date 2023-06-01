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
        private double TrocoMaquina;
        private double Troco;
        private int CodCartao;
        private short BandeiraCartao;

        public Pagamento()
        {
            codigo = 0;
            descricao = "";
            valor = 0;
            FormaPagamento = 0;
            DataPagamento = new DateTime();
            ValorTotal = 0;
            TrocoMaquina = 0;
            Troco = 0;
            CodCartao = 0;
            BandeiraCartao = 0;
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

        public double ModificarTrocoMaquina
        {
            get { return this.TrocoMaquina; }
            set { this.TrocoMaquina = value; }
        } //Fim do GetSet ModificarTrocoMaquina

        public double ModificarTroco
        {
            get { return this.Troco; }
            set { this.Troco = value; }
        } //Fim do GetSet ModificarTroco

        public int ModificarCodCartao
        {
            get { return this.CodCartao; }
            set { this.CodCartao = value;}
        }

        public short ModificarBandeiraCartao
        {
            get { return this.BandeiraCartao; }
            set { this.BandeiraCartao = value; }
        }

        public void CadastrarPagamento(int codigo, string descricao, double valor, short FormaPagamento, DateTime DataPagamento, Double ValorTotal )
        {
            ModificarCodigo = codigo;
            ModificarDescricao = descricao;
            ModificarValor = valor;
            ModificarPagamento = FormaPagamento;
            ModificarData = DataPagamento;
            ModificarValorTotal = ValorTotal;
            ModificarTrocoMaquina = 100;
            ModificarTroco = Troco;
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

        public void VerificarTroco(double entradaDinheiro, double valorProduto)
        {
            Boolean respTroco = false;
            respTroco = ExisteTroco(entradaDinheiro, valorProduto);
            if (respTroco == true )
            {
                ModificarTroco = entradaDinheiro - valorProduto;
            }
            else
            {
                ModificarTroco = 0;
            }
        }//Fim do VerificarTroco

        public string VerificarNotas(double EntradaDinheiro, double valorProduto)
        {
            if (EntradaDinheiro >= valorProduto)
            {
                return "OK";
            }
            else
            {
                return "NOK";
            }
        }// Fim do VerificarNotas

        public Boolean ExisteTroco(double entradaDinheiro, double valorProduto)
        {
            string resposta = VerificarNotas(entradaDinheiro, valorProduto);
            {
                if (entradaDinheiro > valorProduto)
                {
                    return true;
                }
                return false;
            }
        }//Fim do metodo

        public string MenuFormaDePagamento()
        {
            return "Escolha uma das opções abaixo: " + "\n1. Dinheiro \n2. Cartão";
        }//Fim do Metodo

        public void ColetarFormaDePagamento(short opcao)
        {
            ModificarPagamento = opcao;
        }


        public void EfetuarPagamentoDinheiro(short opcao, double entradaPagamento, double valorProduto)
        {
            string resp = "";
            resp = VerificarNotas(entradaPagamento, valorProduto);

            if (resp == "OK")
            {
                ModificarCodigo = ModificarCodigo + 1;
                ModificarValorTotal = valorProduto;
                ModificarPagamento = opcao;
                ModificarData = DateTime.Now;// Pegar a data e hora da transação
                ModificarTrocoMaquina += valorProduto;
                VerificarTroco(entradaPagamento, valorProduto);
                imprimir();
            }
        }//Fim do Metodo


        public void EfetuarPagamentoCartao(double entradaPagamento, double valorProduto, int codCartao, short BandeiraCartao)
        {
            ModificarCodigo = ModificarCodigo + 1;
            ModificarValorTotal = valorProduto;
            ModificarPagamento = 2;
            ModificarData = DateTime.Now;// Pegar a data e hora da transação
            ModificarBandeiraCartao = BandeiraCartao;
            ModificarCodCartao = codCartao;
            imprimir();
        }

        //Metodo Imprimir
        public string imprimir()
        {
            return "Codigo: " + ModificarCodigo + "\nValor Total: " + ModificarValorTotal + "Troco: " + ModificarTroco + "\nForma de Pagamento: " + ModificarPagamento + "\nData e Hora: " + ModificarData; 
        }// Fim do Metodo Imprimir

    }//Fim da Classe
}// Ffim do Projeto
