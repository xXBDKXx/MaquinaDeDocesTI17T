using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaDeDoces
{
     class ControlProduto
    {
        Produto prod;
        private int opcao;

        public ControlProduto()
        {
            prod = new Produto();
            ModificarOpcao = -1;
        }// Fim do construtor

        // Metodo GetSet
        public int ModificarOpcao
        { 
            get { return opcao; }
            set { opcao = value; }
        }// Fim do metodo GetSet



        public void Menu() 
        {
            Console.WriteLine("Escolha uma das opções abaixo: \n" + "1.Cadastrar Produto\n" + "2.Consultar um Produto\n" + "3.Atualizar um produto\n" + "4. Mudar Situacao\n");
            ModificarOpcao = Convert.ToInt32(Console.ReadLine());
        }//Fim do metodo menu

        public void Operacao()
        {
            do
            {
                Menu();// Mostrando o menu na tela
                switch (ModificarOpcao)
                {
                    case 0:
                        Console.WriteLine("Obrigado");
                        Console.Clear(); //Limpar o console
                        break;
                    case 1:
                        ColetarDados();
                        Console.Clear();
                        break;
                    case 2:
                        ConsultarDados();
                        Console.Clear();
                        break;
                    case 3:
                        Atualizar();
                        Console.Clear();
                        break;
                    case 4:
                        AlterarSituacao();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção escolhida não é valida");
                        Console.Clear();
                        break;
                }//Fim do Switch
            } while (ModificarOpcao != 0);
        }

        //Criar um metodo para a solicitação de dados
        public void ColetarDados()
        {
            // Coletar dados
            Console.WriteLine("Informe um codigo: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o nome do produto: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Faça uma breve descrição do Produto: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Informe o preço do produto: ");
            double preco = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Informe a quantidade de produtos em estoque: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a data de validade do lote do produto: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe a situação do produto True - Ativo | False - Inativo");
            Boolean situacao = Convert.ToBoolean(Console.ReadLine());

            //Cadastrar o Produto
            prod.CadastrarProduto(codigo, nome, descricao, preco, quantidade, data, situacao);
            Console.WriteLine("Dado Registrado!");

        }// Fim do ColetarDados

        //Consultar
        public void ConsultarDados()
        {
            Console.WriteLine("\n\n\nInforme o codigo do produto que deseja consultar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Escrever o resultado da consulta na tela
            Console.WriteLine("Os dados do produto escolhido são: \n\n\n" + prod.ConsultarProduto(codigo));

        }// Fim do metodo

        //Atualizar
        public void Atualizar()
        {
            // Atualizar produto
            Console.WriteLine("\n\nInforme o codigo do produto que deseja atualizar");
            int codigo = Convert.ToInt32(Console.ReadLine());
            short campo = 0;

            do
            {
                Console.WriteLine("Informe o campo que deseja atualizar de acordo com a regra abaixo: \n" + "1.Nome\n" + "2.Descrição\n" + "3.Preço\n" + "4.Quantidade\n" + "5.Data de Validade\n" + "6.Situação");
                campo = Convert.ToInt16(Console.ReadLine());
                //Avisar o Usuário 
                if((campo < 1) || (campo > 6))
                {
                    Console.WriteLine("Erro, Escolha um código entre 1 e 6");
                }// Fim do If
            } while ((campo < 1) || (campo > 6));

            Console.WriteLine("Informe o novo dado: ");
            string novoDado = Console.ReadLine();

            // Chamar o metodo de atualização
            prod.AtualizarProduto(codigo, campo, novoDado);
            Console.WriteLine("Alterado!");
        }// Fim do Atualizar

        //Alterar situação
        public void AlterarSituacao()
        {
            Console.WriteLine("Informe o codigo do produto que deseja alterar o status: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chamar o metodo Alterar a situcao
            prod.AlterarSituacao(codigo);
            Console.WriteLine("Alterado!");
        }// Fim do Metodo



    }// Fim da Classe
}// Fim do projeto
