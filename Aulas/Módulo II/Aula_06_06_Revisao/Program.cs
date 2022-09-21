using System;

namespace Aula_06_06_Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Runners runners = new Runners();
            Form formRunner = new Form();

            runners.FirstName = "Jorge";

            runners.LastName = "Da Lapa";

            formRunner.Country = "Brasil";

            formRunner.Genre = "M";

            formRunner.Number = 32;

            runners.Form = formRunner;

            runners.TestTime = decimal.Parse(Console.ReadLine());

            Pitchers pitchers = new Pitchers();
            Form formPitcher = new Form();

            pitchers.FirstName = "Jonas";

            pitchers.LastName = "Silva";

            formPitcher.Country = "Inglaterra";

            formPitcher.Genre = "M";

            formPitcher.Number = 23;

            pitchers.Form = formPitcher;

            for (int i = 0; i < 6; i++)
            {
                pitchers.AddMark();
            }

            Console.WriteLine(runners.ToString());

            Console.WriteLine("\n" + pitchers.ToString());
        }
    }
}
