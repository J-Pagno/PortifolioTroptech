using System;

namespace E02
{
    public class MenuOptions
    {
        public static void PrintMenu()
        {
            Console.WriteLine("Olá, o que deseja fazer?");
            Console.WriteLine("1 - Adicionar contato");
            Console.WriteLine("2 - Remover um contato específico");
            Console.WriteLine("3 - Verificar se um contato existe");
            Console.WriteLine("4 - Verificar quantas pessoas com um certo nome existem na lista");
            Console.WriteLine("5 - Exibir listar ordenada alfabeticamente");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Para sair, digite 'encerrar' no campo de nome do contato...");
            Console.ResetColor();
        }
    }
}
