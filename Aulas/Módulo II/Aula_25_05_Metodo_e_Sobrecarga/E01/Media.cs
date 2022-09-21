using System;

namespace E01
{
    public class Media
    {
        private double _sumNotes;

        public Media(params double[] testNotes)
        {
            foreach (var item in testNotes)
            {
                _sumNotes += item;
            }
        }

        public double GetFullMedia()
        {
            return (_sumNotes) / 3;
        }

        public int GetIntegerMedia()
        {
            return Convert.ToInt16(Math.Round((double)((_sumNotes) / 3)));
        }
    }
}
