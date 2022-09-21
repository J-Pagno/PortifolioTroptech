using System;

namespace E01
{
    public class Person
    {
        private string _name;
        private int _age;
        private string _treatmentPronoun;
        private DateTime _birthYear;
        private int _phone;

        public string name
        {
            get
            {
                if (_name == null)
                    return "";
                else
                    return $"{_treatmentPronoun} {_name}";
            }
            set
            {
                if (value != null)
                    _name = value;
            }
        }

        public int age
        {
            get { return Convert.ToInt16(DateTime.Now.Year) - Convert.ToInt16(_birthYear.Year); }
        }

        public string treatmentPronoun
        {
            get { return _treatmentPronoun; }
            set { _treatmentPronoun = value; }
        }
        public DateTime birthYear
        {
            get { return _birthYear; }
            set { _birthYear = value; }
        }
        public int phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
    }
}
