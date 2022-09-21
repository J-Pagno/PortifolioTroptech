namespace E04
{
    public class Person
    {
        private string _name;
        private double _weight;
        private double _height;
        private string _gender;

        public Person(string name, double weight, double height, string gender)
        {
            _name = name;
            _weight = weight;
            _height = height;
            _gender = gender;
        }

        public void ChangeName(string newName)
        {
            _name = newName;
        }

        public void ChangeWeight(double newWeight)
        {
            _weight = newWeight;
        }

        public void ChangeHeight(double newHeight)
        {
            _height = newHeight;
        }

        public void ChangeGender(string newGender)
        {
            _gender = newGender;
        }

        public string GetName()
        {
            return _name;
        }

        public double GetWeight()
        {
            return _weight;
        }

        public double GetHeight()
        {
            return _height;
        }

        public string GetGender()
        {
            return _gender;
        }

        public double GetIMC()
        {
            return _weight / (_height * _height);
        }
    }
}
