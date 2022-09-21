namespace E03
{
    public class Retangle
    {
        private double _height;

        private double _width;

        public Retangle()
        {
            _height = 0;
            _width = 0;
        }

        public Retangle(double width, double height)
        {
            _height = height;
            _width = width;
        }

        public void ChangeHeight(double height)
        {
            _height = height;
        }

        public void ChangeWidth(double width)
        {
            _width = width;
        }

        public double GetWidth()
        {
            return _width;
        }

        public double GetHeight()
        {
            return _height;
        }

        public double GetRetangleArea()
        {
            return _height * _width;
        }
    }
}
