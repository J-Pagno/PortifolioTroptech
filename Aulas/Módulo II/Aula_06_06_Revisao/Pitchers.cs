using System;
using System.Collections.Generic;

namespace Aula_06_06_Revisao
{
    public class Pitchers : TrackAndField
    {
        private List<decimal> _markList = new List<decimal>(6);

        private string _lastMark;

        public void AddMark()
        {
            do
            {
                Console.WriteLine($"Digite o valor da marca {_markList.Count + 1}");
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                {
                    _markList.Add(value);
                    return;
                }
                else
                {
                    Console.WriteLine("Valor inválido!");
                }
            } while (true);
        }

        public decimal VerifyMaxMark()
        {
            decimal maxMark = 0;

            foreach (var mark in _markList)
            {
                if (mark > maxMark || mark == 0)
                    maxMark = mark;
            }

            return maxMark;
        }

        public override string ToString()
        {
            return $"Corredor:\n'---------------------------------'\n| {this.FullName} |\n| {this.Form.Number} |\n| {this.Form.Country} |\n'---------------------------------'\nResultado: {this.VerifyMaxMark()}.";
        }
    }
}
