﻿using System;
using System.Collections.Generic;

namespace E02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();

            Gang gang = new Gang();

            Console.WriteLine("Digite o nome da turma");
            gang.name = Console.ReadLine();

            for (int i = 0; i < 5; i++)
            {
                Student student = new Student();

                Console.WriteLine("Escreva o nome do aluno: ");
                student.name = Console.ReadLine();

                Console.WriteLine("Escreva o número da matrícula do aluno: ");
                bool isNumber = int.TryParse(Console.ReadLine(), out int registration);
                
                if (!isNumber)
                {
                    Console.WriteLine("Valor inválido");
                    i--;
                    continue;
                }
                else
                    student.registration = registration;

                Console.WriteLine("Escreva a nota de prova do aluno: ");
                isNumber = int.TryParse(Console.ReadLine(), out int grades);
                
                if (!isNumber)
                {
                    Console.WriteLine("Valor inválido");
                    i--;
                    continue;
                }
                else
                {
                    student.grades = grades;
                }

                studentList.Add(student);

                gang.studentsList.Add(student);

                Console.Clear();
            }

            Console.WriteLine($"A turma {gang.name} teve a média de {gang.GangMediaCalculator()}");

            foreach (var student in studentList)
            {
                Console.WriteLine($"Nome: {student.name}");
                
                Console.WriteLine($"Número de Matrícula: {student.registration}");
                
                Console.WriteLine($"Nota de Prova: {student.grades}");
                
                Console.WriteLine("======================");
            }
        }
    }
}
