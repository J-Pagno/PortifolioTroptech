using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CSharpSqlServer.Classes;
using CSharpSqlServer.Classes.DAO;

namespace CSharpSqlServer.ConsoleApp
{
    class Program
    {

        static AlunoDao _alunoDao = new AlunoDao();
        static List<Aluno> _listaAlunos = new List<Aluno>();
        static Aluno _alunoBuscado = new Aluno();
        static string _opcao = "";

        static void Main(string[] args)
        {
            Menu();
            AtribuiOpcaoMenu();
        }

        //MENU
        public static void Menu()
        {
            Console.WriteLine("--          MENU ALUNO         --");
            Console.WriteLine("Escolha uma opção abaixo:");
            Console.WriteLine("1- Adicionar aluno");
            Console.WriteLine("2- Buscar todos os alunos");
            Console.WriteLine("3- Buscar por matricula");
            Console.WriteLine("4- Buscar por texto");
            Console.WriteLine("5- Editar aluno");
            Console.WriteLine("6- Deletar aluno");
            Console.Write("=> ");
            _opcao = Console.ReadLine();
        }

        public static void AtribuiOpcaoMenu()
        {
            switch (_opcao)
            {
                case "1":
                    Console.Clear();
                    AdicionarAluno();
                    break;
                case "2":
                    Console.Clear();
                    BuscarTodosAlunos();
                    Console.ReadKey();
                    break;
                case "3":
                    Console.Clear();
                    BuscarAlunoPorMatricula();
                    Console.ReadKey();
                    break;
                case "4":
                    Console.Clear();
                    BuscarAlunoPorTexto();
                    Console.ReadKey();
                    break;
                case "5":
                    Console.Clear();
                    AtualizarAluno();
                    break;
                case "6":
                    Console.Clear();
                    DeletarAluno();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    break;
            }
        }
        //MENU

        //CRUD
        public static void AdicionarAluno()
        {
            Console.WriteLine("--            CADASTRO ALUNO            --");

            Aluno novoAluno = new Aluno();
            Console.WriteLine("Digite uma matricula:");
            novoAluno.Matricula = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite um nome:");
            novoAluno.Nome = Console.ReadLine();

            Console.WriteLine("Digite a idade:");
            novoAluno.Idade = int.Parse(Console.ReadLine());

            _alunoDao.AdicionarAluno(novoAluno);

        }

        public static void BuscarTodosAlunos()
        {
            Console.WriteLine("--                LISTA ALUNO               --");

            _listaAlunos = _alunoDao.BuscarTodos();

            foreach (var item in _listaAlunos)
            {
                Console.WriteLine($"{item}");
            }

        }

        public static void BuscarAlunoPorMatricula()
        {
            Console.WriteLine("Digite a matricula do aluno:");
            var matriculaAluno = Convert.ToInt32(Console.ReadLine());

            _alunoBuscado = _alunoDao.BuscarAlunoPorMatricula(matriculaAluno);

            Console.WriteLine($"Aluno encontrado:\n{_alunoBuscado}");

        }

        public static void BuscarAlunoPorTexto()
        {
            Console.WriteLine(" --                    ALUNO                  -- \n");

            Console.WriteLine("Digite o texto do aluno:");
            var texto = Console.ReadLine();

            _listaAlunos = _alunoDao.BuscarAlunoPorNome(texto);

            foreach (var item in _listaAlunos)
            {
                Console.WriteLine($"{item}");
            }

        }

        public static void AtualizarAluno()
        {
            Console.WriteLine("Digite uma matricula:");
            _alunoBuscado.Matricula = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite um nome:");
            _alunoBuscado.Nome = Console.ReadLine();

            Console.WriteLine("Digite um idade:");
            _alunoBuscado.Idade = Convert.ToInt32(Console.ReadLine());

            _alunoDao.AtualizarAluno(_alunoBuscado);

        }

        public static void DeletarAluno()
        {
            Console.WriteLine("Digite a matricula do aluno:");
            _alunoBuscado.Matricula = Convert.ToInt32(Console.ReadLine());

            _alunoDao.DeletarAluno(_alunoBuscado);
        }
        //CRUD

    }
}
