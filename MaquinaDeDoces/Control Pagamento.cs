using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaDeDoces
{
    class Control_Pagamento
    {
        Pagamento pgto;
        private short opcao;

        public Control_Pagamento()
        {
            pgto = new Pagamento();
        }// Fim do construtor

        //Get Set

        public short ModificarOpcao
        {
            get { return opcao; }
            set { this.opcao = value; }
        }// Fim do metodo

        public void EscolherFormaDePagamento()
        {
            Console.WriteLine(pgto.MenuFormaDePagamento());//Mostrando o menu na tela
            ModificarOpcao = Convert.ToInt16(Console.ReadLine());//Coletando a resposta
        }//Fim do registrar pagamento
       
        public void Operacao()
        {
            EscolherFormaDePagamento();

            switch (ModificarOpcao)
            {
                case 1:
                    Console.WriteLine("Pagamento com Dinheiro: \n\n");
                    Console.WriteLine("Valor Inserido na máquina: ");
                    double valorInserido = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("\n\nValor do Produto: ");
                    double valorProduto = Convert.ToDouble(Console.ReadLine());

                    // Utilizar o Metodo Efetuar Pagamento Dinheiro
                    pgto.EfetuarPagamentoDinheiro(valorInserido, valorProduto);
                    Console.WriteLine(pgto.imprimir());
                    break;

                case 2:
                    Console.WriteLine("Pagamento com Cartão: \n\n");
                    Console.WriteLine("\n\nValor do Produto: ");
                    valorProduto = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("\n\nCódigo do Cartão");
                    int codCartao = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\n\nBandeira do Cartão \n1. Visa\n2. MasterCard\n3. Elo");
                    short bandeiraCartao = Convert.ToInt16(Console.ReadLine());

                    // Utilizar o Metodo Efetuar Pagamento Dinheiro
                    pgto.EfetuarPagamentoCartao(valorProduto, codCartao, bandeiraCartao);
                    Console.WriteLine(pgto.imprimir());
                    break;
                default:
                    Console.WriteLine("Impossivel Realizar a Operação tente Novamente!");
                    break;
            }//Fim do Switch
        }//Fim da Metodo Operação

    }//Fim da Classe
}
