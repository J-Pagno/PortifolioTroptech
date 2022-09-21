using System;

namespace Aula_06_06_Revisao
{
    public class Runners : TrackAndField
    {
        private decimal _testTime;

        public decimal TestTime
        {
            get => _testTime;
            set => _testTime = value;
        }

        public override string ToString()
        {
            return $"Corredor:\n'---------------------------------'\n| {this.FullName} |\n| {this.Form.Number} |\n| {this.Form.Country} |\n'---------------------------------'\nResultado: {this._testTime}.";
        }
    }
}
