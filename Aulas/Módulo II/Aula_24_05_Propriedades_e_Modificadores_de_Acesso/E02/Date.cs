namespace E02
{
    public class Date
    {
        private int _day;

        private int _month;

        private int _year;

        private int _daysToAdd = 0;

        private int _monthsToAdd = 0;

        private int _yearsToAdd = 0;

        public int Day
        {
            get { return _day; }
        }

        public int Month
        {
            get { return _month; }
        }

        public int Year
        {
            get { return _year; }
        }

        public string CompleteDate
        {
            get { return $"{_day}/{_month}/{_year}"; }
        }

        public int DaysToAdd
        {
            set
            {
                _daysToAdd = value;
                if (_daysToAdd > 0)
                {
                    _day += _daysToAdd;
                }
            }
        }

        public int MonthsToAdd
        {
            set
            {
                _monthsToAdd = value;
                if (_monthsToAdd > 0)
                {
                    _month += _monthsToAdd;
                }
            }
        }

        public int YearsToAdd
        {
            set
            {
                _yearsToAdd = value;
                if (_yearsToAdd > 0)
                {
                    _year += _yearsToAdd;
                }
            }
        }

        public Date(int day, int month, int year)
        {
            if (day > 0 && day <= 31)
                _day = day;
            else
                _day = 0;

            if (month > 0 && month <= 12)
                _month = month;
            else
                _month = 0;

            if (year > 1999 && year <= 2022)
                _year = year;
            else
                _year = 0;
        }
    }
}
