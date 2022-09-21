using System;
namespace E01
{
    public class Retangle
    {
        private int _retangleBase;

        private int _retangleHeight;

        private double _retangleArea;

        public double RetangleArea
        {
            get
            {
                return _retangleArea;
            }
        }

        public Retangle(int retangleBase, int retangleHeigh)
        {
            _retangleBase = retangleBase;
            _retangleHeight = retangleHeigh;
            _retangleArea = retangleBase * retangleHeigh;
        }
    }
}