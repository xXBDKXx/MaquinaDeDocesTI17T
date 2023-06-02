using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaDeDoces
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conecta as duas classes
            Control_Pagamento controlProd = new Control_Pagamento();
            // Chamar o método principal daquela classe
            controlProd.Operacao();
            

            Console.ReadLine();// Manter a janela aberta nessa situação
        }//Fim do metodos main
    }// Fim da classe
}// Fim do projeto
