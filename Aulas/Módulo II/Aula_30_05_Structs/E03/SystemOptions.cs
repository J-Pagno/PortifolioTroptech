using System;
using System.Collections.Generic;

namespace E03
{
    public class SystemOptions
    {
        public static LinkedList<Student> AddStudent(LinkedList<Student> studentList)
        {
            Student newStudent = new Student();

            Console.WriteLine("Digite o nome do aluno:");
            newStudent.name = Console.ReadLine();

            Console.WriteLine("Digite a idade do aluno:");
            newStudent.age = Console.ReadLine();

            Console.WriteLine("Digite a turma do aluno:");
            newStudent.gang = Console.ReadLine();

            Console.WriteLine("Digite o cep do aluno:");
            newStudent.adderess.CEP = Console.ReadLine();

            Console.WriteLine("Digite o numero da casa do aluno:");
            newStudent.adderess.houseNumber = Console.ReadLine();

            Console.WriteLine("Digite o complemento do aluno:");
            newStudent.adderess.complement = Console.ReadLine();

            studentList.AddLast(newStudent);

            return studentList;
        }

        public static LinkedList<Teacher> AddTeacher(LinkedList<Teacher> teacherList)
        {
            Teacher newTeacher = new Teacher();

            Console.WriteLine("Digite o nome do professor:");
            newTeacher.name = Console.ReadLine();

            Console.WriteLine("Digite a matéria do professor:");
            newTeacher.matter = Console.ReadLine();

            Console.WriteLine("Digite o cpf do professor:");
            newTeacher.cpf = Console.ReadLine();

            Console.WriteLine("Digite o cep do professor:");
            newTeacher.adderess.CEP = Console.ReadLine();

            Console.WriteLine("Digite o numero da casa do professor:");
            newTeacher.adderess.houseNumber = Console.ReadLine();

            Console.WriteLine("Digite o complemento do professor:");
            newTeacher.adderess.complement = Console.ReadLine();

            teacherList.AddLast(newTeacher);

            return teacherList;
        }

        public static void ShowStudentsAndTeachers(
            LinkedList<Student> studentsList,
            LinkedList<Teacher> teachersList
        )
        {
            Console.Clear();

            Console.WriteLine("Lista de alunos cadastrados:");

            foreach (var student in studentsList)
            {
                Console.WriteLine($"{student.name} - {student.gang} - {student.adderess.CEP}");
            }

            Console.WriteLine("Lista de professores cadastrados:");

            foreach (var teacher in teachersList)
            {
                Console.WriteLine($"{teacher.name} - {teacher.matter} - {teacher.adderess.CEP}");
            }

            Console.ReadKey();
        }
    }
}
