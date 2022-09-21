using System;
using System.Threading;
using System.Collections.Generic;

namespace E04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            LinkedList<string> productList = new LinkedList<string>();

            bool ismenuLoop = true;

            do
            {
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Cadastrar um produto no início da lista");
                Console.WriteLine("2 - Cadastrar um produto no final da fila");
                Console.WriteLine(
                    "3 - Cadastrar um produto no meio da lista (não importa se após o primeiro item ou antes do último)"
                );
                Console.WriteLine(
                    "4 - Remover o primeiro produto da lista (deve ser verificado se existe um primeiro item e exibir mensagem se o produto foi removido ou não)"
                );
                Console.WriteLine(
                    "5- Remover o último produto da lista (deve ser verificado se existe um último item e exibir mensagem se o produto foi removido ou não)"
                );
                Console.WriteLine(
                    "6 - Remover um produto pelo seu nome (Deve verificar se existe o produto a excluir e exibir se o produto foi removido ou não)"
                );
                Console.WriteLine("7 - Limpar a lista de produtos");
                Console.WriteLine("8 - Listar produtos");

                int option = Convert.ToInt16(Console.ReadLine());
                string product = "";

                Console.Clear();

                switch (option)
                {
                    case 0:
                        if (productList.Count > 0)
                        {
                            Console.WriteLine("Valores finais da lista: ");
                            for (var node = productList.First; node != null; node = node.Next)
                            {
                                Console.WriteLine("• " + node.Value);
                                Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("A lista está vazia!");
                            Console.ResetColor();
                        }
                        return;
                    case 1:
                        Console.WriteLine(
                            "Digite o nome do produto a ser adicionado no início da lista:"
                        );
                        product = Console.ReadLine();
                        productList.AddFirst(product);
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine(
                            "Digite o nome do produto a ser adicionado no fim da lista:"
                        );
                        product = Console.ReadLine();
                        productList.AddLast(product);
                        break;
                    case 3:
                        Console.WriteLine("Qual o produto a ser adicionado?");
                        product = Console.ReadLine();

                        Console.WriteLine("Onde deseja adicionar um produto?");
                        Console.WriteLine("1 - Após o produto ...\n2 - Antes do produto ...");
                        string addAfterOrBefore = Console.ReadLine();

                        Console.Clear();

                        Console.WriteLine("Produtos listados até agora: ");
                        for (var node = productList.First; node != null; node = node.Next)
                        {
                            Console.WriteLine("• " + node.Value);
                        }

                        if (addAfterOrBefore == "1")
                        {
                            Console.WriteLine("Após qual produto ele será adicionado?");
                            var after = productList.Find(Console.ReadLine());
                            productList.AddAfter(after, product);
                        }
                        else if (addAfterOrBefore == "2")
                        {
                            Console.WriteLine("Antes de qual produto ele será adicionado?");
                            var before = productList.Find(Console.ReadLine());
                            productList.AddBefore(before, product);
                        }

                        Console.WriteLine($"{product} adicionado com sucesso!!");
                        Console.Write("Pressione uma tecla para continuar...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 4:
                        if (productList.Count > 0)
                        {
                            var removedFirstItem = productList.First;
                            productList.RemoveFirst();
                            Console.WriteLine($"O produto removido foi {removedFirstItem.Value}");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("A lista está vazia!");
                            Console.ResetColor();
                        }
                        Console.Write("Pressione uma tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        if (productList.Count > 0)
                        {
                            var removedLastItem = productList.Last;
                            productList.RemoveLast();
                            Console.WriteLine($"O produto removido foi {removedLastItem.Value}");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("A lista está vazia!");
                            Console.ResetColor();
                        }

                        Console.Write("Pressione uma tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        if (productList.Count > 0)
                        {
                            Console.WriteLine("Produtos listados até agora: ");
                            for (var node = productList.First; node != null; node = node.Next)
                            {
                                Console.WriteLine("• " + node.Value);
                            }

                            Console.WriteLine("Informe o produto a ser removido:");
                            product = Console.ReadLine();

                            if (productList.Contains(product))
                            {
                                var removedFirstItem = productList.First;
                                productList.Remove(product);
                                Console.WriteLine(
                                    $"O produto removido foi {removedFirstItem.Value}"
                                );
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("O produto não existe!!");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("A lista está vazia!");
                            Console.ResetColor();
                        }

                        Console.Write("Pressione uma tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    case 7:
                        productList.Clear();

                        Console.WriteLine("A lista foi apagada com sucesso!!");
                        Console.Write("Pressione uma tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 8:
                        if (productList.Count > 0)
                        {
                            Console.WriteLine("Produtos listados até agora: ");
                            for (var node = productList.First; node != null; node = node.Next)
                            {
                                Console.WriteLine("• " + node.Value);
                                Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("A lista está vazia!");
                            Console.ResetColor();
                        }
                        Console.Write("Pressione uma tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Valor inválido");
                        Console.ResetColor();
                        break;
                }
            } while (ismenuLoop);
        }
    }
}
