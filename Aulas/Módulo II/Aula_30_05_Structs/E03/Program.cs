using System;
using System.Collections.Generic;

namespace E03
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Student> studentsList = new LinkedList<Student>();

            LinkedList<Teacher> teachersList = new LinkedList<Teacher>();

            do
            {
                Console.Clear();
                Console.WriteLine("Selecione o que deseja fazer:");
                Console.WriteLine("1 - Cadastrar aluno");
                Console.WriteLine("2 - Cadastrar professor");
                Console.WriteLine("3 - Listar alunos e professores");
                Console.WriteLine("4 - Sair");
                bool isNumber = int.TryParse(Console.ReadLine(), out int userChoice);

                if (!isNumber)
                {
                    Console.WriteLine("Valor inválido!");
                    continue;
                }

                switch (userChoice)
                {
                    case 1:
                        studentsList = SystemOptions.AddStudent(studentsList);
                        break;

                    case 2:
                        teachersList = SystemOptions.AddTeacher(teachersList);
                        break;

                    case 3:
                        SystemOptions.ShowStudentsAndTeachers(studentsList, teachersList);
                        break;
                    case 4:
                        return;

                    default:
                        Console.WriteLine("Valor inválido");
                        break;
                }
            } while (true);
        }
    }
}
