using System;
using System.Collections.Generic;

namespace Atividade1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lista de pedidos
            List<Pedido> pedidos = new List<Pedido>();
            int pedidoSelecionado = 0;
            int opcao;

            do
            {
                Console.WriteLine("\n***********************************");
                Console.WriteLine("*   Olá! O que deseja fazer?      *");
                Console.WriteLine("*   1 - Listar pedidos            *");//Lista todos os pedidos criados
                Console.WriteLine("*   2 - Criar pedido              *");//Cria um pedido novo
                Console.WriteLine("*   3 - Selecionar pedido         *");//Seleciona um pedido dentre os criados
                Console.WriteLine("*   4 - Adicionar item ao pedido  *");//Adiciona um item ao pedido selecionado
                Console.WriteLine("*   5 - Finalizar pedido          *");//Finaliza um pedido retornando a soma dos itens dentro do mesmo
                Console.WriteLine("*   0 - Sair                      *");//Finaliza o programa
                Console.WriteLine("***********************************");
                Console.Write(">>>");
                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        //Lista todos os pedidos criados
                        Console.Clear();
                        if (pedidos.Count > 0)
                        {
                            //Console.WriteLine("\n");
                            for (int i = 0; i < pedidos.Count; i++)
                            {
                                double t = pedidos[i].FinalizarPedido();
                                t.ToString();
                                if (i == pedidoSelecionado)
                                {
                                    Console.Write("* ");
                                }
                                Console.Write($"Pedido {(i + 1)} ---> R${string.Format("{0:N2}", t)}\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n*  Não há pedidos registrados!  *");
                        }
                        break;

                    case 2:
                        //Cria um pedido novo
                        Console.Clear();
                        Pedido pedido = new Pedido();
                        pedidos.Add(pedido);
                        Console.WriteLine("\n*  Pedido criado!  *\n");
                        break;

                    case 3:
                        //Seleciona um pedido dentre os criados
                        Console.Clear();
                        if (pedidos.Count > 0)
                        {
                            Console.WriteLine($"\n*  Qual pedido deseja selecionar? (1 - {pedidos.Count})  *");
                            Console.Write(">>>");
                            pedidoSelecionado = int.Parse(Console.ReadLine()) - 1;
                            if (pedidoSelecionado < pedidos.Count)
                            {
                                Console.Clear();
                                Console.WriteLine($"\n*  Pedido {(pedidoSelecionado + 1)} selecionado!  *");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("*  Este pedido não existe!  *");
                                pedidoSelecionado = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n*  Nenhum pedido aberto!  *");
                        }
                        break;

                    case 4:
                        //Adiciona um item ao pedido selecionado
                        Console.Clear();
                        if (pedidos.Count > 0)
                        {
                            char a;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("\n*  Insira uma descrição para o item:  *");
                                Console.Write(">>>");
                                string s = Console.ReadLine();
                                Console.WriteLine("*  Qual o valor unitário deste item?  *");
                                Console.Write(">>>");
                                double.TryParse(Console.ReadLine(), out double d);
                                Console.WriteLine("*  Quantos itens serão adicionados ao pedido?  *");
                                Console.Write(">>>");
                                int.TryParse(Console.ReadLine(), out int i);

                                pedidos[pedidoSelecionado].IncluirPedido(s, d, i);

                                Console.Clear();

                                Console.WriteLine("\n*  Item adicionado ao pedido!\n  *");

                                Console.WriteLine("*  Deseja adicionar outro item ao pedido? (S / N)  *");
                                Console.Write(">>>");
                                a = Console.ReadKey().KeyChar;

                            } while (a == 's' || a == 'S');
                        }
                        else
                        {
                            Console.WriteLine("\n*  Nenhum pedido aberto!  *");
                        }
                        break;

                    case 5:
                        //Finaliza um pedido retornando a soma dos itens dentro do mesmo
                        Console.Clear();
                        if (pedidos.Count > 0)
                        {
                            Console.WriteLine("**************************************************");
                            Console.WriteLine("Finalizando pedido " + (pedidoSelecionado + 1));
                            pedidos[pedidoSelecionado].ExibirPedido();
                            double t = pedidos[pedidoSelecionado].FinalizarPedido();
                            t.ToString();
                            Console.WriteLine($"Valor total do pedido: R${string.Format("{0:N2}", t)}\n");
                            pedidos.RemoveAt(pedidoSelecionado);
                            Console.WriteLine($"Pedido {(pedidoSelecionado + 1)} removido!");
                            Console.WriteLine("**************************************************");
                            pedidoSelecionado = 0;
                        }
                        else
                        {
                            Console.WriteLine("\n*  Nenhum pedido em aberto!  *");
                        }
                        break;

                    case 0:
                        //Finaliza o programa
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\n*  Escolha uma opção válida!  *\n");
                        break;
                }
            } while (opcao != 0);
        }
    }
}
