namespace E02_Bonus
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
                int sumDays = _daysToAdd + _day;
                if (_daysToAdd > 0 && sumDays <= 31)
                    _day += _daysToAdd;
                else
                {
                    if (sumDays > 31)
                    {
                        _day = sumDays % 31;
                        _month += (sumDays / 31);
                    }
                }
            }
        }

        public int MonthsToAdd
        {
            set
            {
                _monthsToAdd = value;

                int sumMonths = _monthsToAdd + _month;

                if (_monthsToAdd > 0 && sumMonths <= 12)
                    _month += _monthsToAdd;
                else
                {
                    if (sumMonths > 12)
                    {
                        _month = sumMonths % 12;
                        _year += (sumMonths / 12);
                    }
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
            if (day > 0)
                DaysToAdd = day;
            else
                _day = 0;

            if (month > 0)
                MonthsToAdd = month;
            else
                _month = 0;

            YearsToAdd = year;
        }
    }
}
