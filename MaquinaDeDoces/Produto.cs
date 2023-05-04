using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaquinaDeDoces
{
    class Produto
    {
        // Definição de variaveis
        private int codigo;
        private string nome;
        private string descricao;
        private double preco;
        private int quantidade;
        private DateTime dtValidade;
        private Boolean situacao;

        // Metodo construtor
        public Produto() 
        { 
            ModificarCodigo = 0;
            ModificarNome = "";
            ModificarDescricao = "";
            ModificarPreco = 0;
            ModificarQuantidade = 0;
            ModificarValidade = new DateTime();//0000/00/00 00:00:00
            ModificarSituacao = false;
        }// Fim do metodo construtor

        public Produto(int codigo, string nome, string descricao, double preco, int quantidade, DateTime dtValidade, Boolean situacao)
        {
            ModificarCodigo = codigo; // This é utilizado para fazer referencia a variavel criada
            ModificarNome = nome;
            ModificarDescricao = descricao;
            ModificarPreco = preco;
            ModificarQuantidade = quantidade;
            ModificarValidade = dtValidade;
            ModificarSituacao = situacao;
        }// Fim do metodo construtor com parametros

        // Metodos Get e Set
        // Metodos de Acesso e Modificação
        
        public int ModificarCodigo
        {
            get {
                return this.codigo;
            }// FIm do Get - Retornar codigo
            
            set {
                this.codigo = value;
            }//Fim do Set - Modificar o codigo
        
        }// FIm do ModificarCOdigo

        public string ModificarNome
        { 
            get { 
                return this.nome; 
            } 
            
            set { 
                this.nome = value;
            } 
        }//Fim do ModificarNome


        public string ModificarDescricao 
        {
            get { 
                return this.descricao;
            }

            set {
                this.descricao = value;
            }
        }//Fim do ModificarDescricao

        public double ModificarPreco 
        { 
            get { 
                return this.preco; 
            }
            
            set {
                this.preco = value;
            } 
        }//Fim do ModificarPreco

        public int ModificarQuantidade
        {
            get { 
                return this.quantidade;
            }
            
            set {
                this.quantidade = value;
            }
        }// Fim do ModificarQuantidade

        public DateTime ModificarValidade
        {
            get {
                return this.dtValidade;
            }
            set {
                this.dtValidade = value;
            }
        }//Fim do ModificarValidade

        public Boolean ModificarSituacao 
        { 
            get { 
                return this.situacao;
            } 
            set { 
                this.situacao = value;
            } 
        }// Fim do ModificarSituacao


        // Metodo CadastrarProduto
        public void CadastrarProduto(
                int codigo,
                string nome,
                string descricao,
                double preco,
                int quantidade,
                DateTime dtValidade,
                Boolean situacao
            )
        {
            ModificarCodigo = codigo;
            ModificarNome = nome;
            ModificarDescricao = descricao;
            ModificarPreco = preco;
            ModificarQuantidade = quantidade;
            ModificarValidade = dtValidade;
            ModificarSituacao= situacao;
        }//Fim do Metodo CadastrarProduto


        //Metodo ConsultarProduto
        public string ConsultarProduto(int codigo) 
        {
            string msg = "";// Criando uma Variavel local

            if (ModificarCodigo == codigo)
            {
                msg = "\nCódigo: " + ModificarCodigo +
                      "\nNome:" + ModificarNome +
                      "\nDescrição: " + ModificarDescricao +
                      "\nPreço: " + ModificarPreco +
                      "\nQuantidade: " + ModificarQuantidade +
                      "\nValidade: " + ModificarValidade +
                      "\nSituação: " + ModificarSituacao;
            }
            else 
            {
                msg = "O Código Digitado Não Existe!";
            }

            return msg;

        }//Fim do Metodo

        // Metodo AtualizarProduto
        public Boolean AtualizarProduto(int codigo, int campo, string novoDado) 
        { 
            Boolean flag = false;// Variavel Local

            if(ModificarCodigo == codigo)
            {
                switch (campo)
                {
                    case 1:
                        ModificarNome = novoDado;
                        flag = true;
                        break;
                    case 2:
                        ModificarDescricao = novoDado;
                        flag = true;
                        break;
                    case 3:
                        ModificarPreco = Convert.ToDouble(novoDado);
                        flag = true;
                        break;
                    case 4:
                        ModificarQuantidade = Convert.ToInt32(novoDado);
                        flag = true;
                        break;
                    case 5:
                        ModificarValidade = Convert.ToDateTime(novoDado);
                        flag = true;
                        break;
                    case 6:
                        ModificarSituacao = Convert.ToBoolean(novoDado);
                        flag = true;
                        break;
                    default:
                        break;
                }//Fim do Escolha

                return flag;
            }// Fim do IF
            return flag;
        }// Fim do Atualizar Produto

        //DesativarProduto
        public Boolean AlterarSituacao(int codigo) 
        {
            Boolean flag = false;

            if (ModificarCodigo == codigo)
            {
                if (ModificarSituacao == true)
                {
                    ModificarSituacao = false;
                }
                else
                {
                    ModificarSituacao = true;
                }
                flag = true;
            }
            return flag;
        }// FIm do AlterarSituacao


        // Solicitar produtos
        public Boolean SolicitarProduto(int codigo) 
        { 
            if (ModificarCodigo == codigo)
            {
                if (ModificarQuantidade <= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }// FIm do If
            return false;
        }
       
    }//Fim da Classe
}//Fim do projeto
