namespace E01
{
    public class Client
    {
        private string _name;

        private int _age;

        private Adderess _adderess;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string street
        {
            get { return _adderess.street; }
            set { _adderess.street = value; }
        }
        public string district
        {
            get { return _adderess.district; }
            set { _adderess.district = value; }
        }

        public string houseNumber
        {
            get { return _adderess.houseNumber; }
            set { _adderess.houseNumber = value; }
        }

        public string city
        {
            get { return _adderess.city; }
            set { _adderess.city = value; }
        }

        public string state
        {
            get { return _adderess.state; }
            set { _adderess.state = value; }
        }
    }
}
