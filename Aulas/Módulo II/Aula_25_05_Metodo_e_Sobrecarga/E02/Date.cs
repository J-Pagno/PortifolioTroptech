namespace E02
{
    public class Date
    {
        public static int daysToHours(int days)
        {
            return days * 24;
        }

        public static int daysToMinutes(int days)
        {
            return (days * 24) * 60;
        }

        public static int daysToSeconds(int days)
        {
            return (days * 24) * 3600;
        }
    }
}
