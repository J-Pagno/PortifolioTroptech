﻿using System;

namespace CSharpSqlServer.Classes
{
    public class Aluno
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Aluno()
        {
            
        }

        public override string ToString()
        {
            return $"Matricula: {Matricula} Nome: {Nome} Idade: {Idade}";
        }
    }
}
