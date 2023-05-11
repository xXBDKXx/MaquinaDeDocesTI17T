using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaDeDoces
{
    class Control_Pagamento
    {
        Pagamento Pag = new Pagamento();
        private int opcao;

        public Control_Pagamento()
        {
            Pag = new Pagamento();
            ModificarOpcao = -1;
        }// Fim do construtor

        public int ModificarOpcao
        {
            get { return opcao; }
            set { opcao = value; }
        }// Fim do metodo GetSet
        public void Menu()
        {
            Console.WriteLine("Qual a Forma de Pagamento: \n" + "1.Cartão\n" + "2.Dinheiro\n");
            ModificarOpcao = Convert.ToInt32(Console.ReadLine());
        }//Fim do metodo menu

        public void PagamentoFinal(int codigo)
        {
            do
            {
                Menu();
                switch (ModificarOpcao)
                {
                    case 0:
                        Console.WriteLine("Compra Cancelada");
                        Console.Clear(); //Limpar o console
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("Opção escolhida não é valida");
                        Console.Clear();
                        break;
                }// Fim do Switch
            } while (ModificarOpcao != 0) ;
        }

    }//Fim da Classe
}
