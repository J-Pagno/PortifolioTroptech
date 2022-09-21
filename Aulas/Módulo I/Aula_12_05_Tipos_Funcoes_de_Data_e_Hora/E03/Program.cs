using System;

namespace E03
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = DateTime.Now;

            string[] dateModified = new String[7];

            for (int i = 0; i < 7; i++)
            {
                dateModified[i] = date.AddDays(i + 1).ToLongDateString();
            }

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"► Daqui {i + 1} dia(s) será '{dateModified[i]}'");
            }
        }
    }
}
