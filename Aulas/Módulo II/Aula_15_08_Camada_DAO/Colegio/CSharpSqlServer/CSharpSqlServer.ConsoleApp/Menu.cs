using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CSharpSqlServer.Classes;
using CSharpSqlServer.Classes.DAO;

namespace CSharpSqlServer.ConsoleApp
{
    public static class Menu
    {
        static AlunoDAO _alunoDao = new AlunoDAO();

        public static void MenuPrincipal()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Gerenciamento de Produtos:");

                Console.WriteLine("a. Adicionar aluno");
                Console.WriteLine("b. Editar aluno");
                Console.WriteLine("c. Deletar aluno");
                Console.WriteLine("d. Buscar todos os alunos");
                Console.WriteLine("e. Buscar aluno por nome");
                Console.WriteLine("f. Buscar aluno pela matricula");
                Console.WriteLine("g. Sair");

                var opcaoEscolhida = Console.ReadLine();

                switch (opcaoEscolhida.ToLower())
                {
                    case "a":
                        AdicionarAluno();
                        break;

                    case "b":
                        AtualizarAluno();
                        break;

                    case "c":
                        // DeletarAluno();
                        break;

                    case "d":
                        BuscarTodosOsAlunos();
                        break;

                    case "e":
                        // BuscarAlunoPelaMatricula();
                        break;

                    case "f":
                        // BuscarAlunoPeloNome();
                        break;

                    case "g":
                        return;

                    default:
                        Aviso("Opção Inválida!");
                        break;
                }
            } while (true);
        }

        public static void Aviso(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(msg);

            Console.ResetColor();
            Console.ReadKey();

            Console.Clear();
        }

        public static void AdicionarAluno()
        {
            Console.Clear();

            Aluno aluno = new Aluno();

            Console.WriteLine("--- CADASTRO DE ALUNO ---");

            Console.WriteLine("Digite a matricula do aluno: ");
            aluno.Matricula = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do aluno: ");
            aluno.Nome = Console.ReadLine();

            Console.WriteLine("Digite a idade do aluno: ");
            aluno.Idade = int.Parse(Console.ReadLine());

            _alunoDao.AdicionarAluno(aluno);
        }

        //Continuar daqui

        public static void AtualizarAluno()
        {
            Console.Clear();

            Console.WriteLine("--- ATUALIZAÇÃO DE PRODUTO ---");

            bool idProduto;
            Aluno aluno = new();

            Console.WriteLine("Digite a matricula do aluno: ");
            aluno.Matricula = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o novo nome do aluno: ");
            aluno.Nome = Console.ReadLine();

            Console.WriteLine("Digite a nova decrição do produto: ");
            aluno.Idade = int.Parse(Console.ReadLine());

            _alunoDao.AtualizarAluno(aluno);
        }

        public static void DeletarAluno()
        {
            Console.Clear();

            Console.WriteLine("--- EXCLUSÃO DE PRODUTO ---");

            bool idProduto;
            int id;

            do
            {
                Console.WriteLine("Digite a identificação do produto: ");
                idProduto = int.TryParse(Console.ReadLine(), out id);
            } while (!idProduto);
        }

        // public static void BuscarTodosOsAlunos()
        // {
        //     Console.Clear();

        //     Console.WriteLine("--- BUSCA DE PRODUTO PELA DESCRIÇÃO ---");

        //     Console.WriteLine("Digite a descrição do produto: ");
        //     string descricaoProduto = Console.ReadLine();

        //     Console.ReadKey();
        // }

        public static void BuscarProdutoPeloIdentificador()
        {
            Console.Clear();

            bool validIdProduto;
            int idProduto;

            do
            {
                Console.WriteLine("--- BUSCA DE PRODUTO PELO IDENTIFICADOR   ---");

                Console.WriteLine("Digite a descrição do produto: ");
                validIdProduto = int.TryParse(Console.ReadLine(), out idProduto);
            } while (!validIdProduto);

            Console.ReadKey();
        }

        public static void BuscarTodosOsAlunos()
        {
            Console.Clear();

            List<Aluno> listaDeAlunos = _alunoDao.BuscarTodosOsAlunos();

            Console.Write("Matrícula");

            Console.CursorLeft = 15;

            Console.Write(" | Nome");

            Console.CursorLeft = 40;

            Console.WriteLine(" | Idade");

            Console.WriteLine("—————————————————————————————————————————————————————————————————");

            foreach (var aluno in listaDeAlunos)
            {
                Console.Write(aluno.Matricula);

                Console.CursorLeft = 15;

                Console.Write(" | ");

                Console.Write(aluno.Nome);

                Console.CursorLeft = 40;

                Console.Write(" | ");

                Console.WriteLine(aluno.Idade);
            }

            Console.ReadKey();
        }
    }
}
