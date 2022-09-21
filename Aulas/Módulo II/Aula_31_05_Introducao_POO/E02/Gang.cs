using System.Collections.Generic;

namespace E02
{
    public class Gang
    {
        public string name { get; set; }

        public List<Student> studentsList = new List<Student>();

        public double GangMediaCalculator()
        {
            double gangMedia = 0;

            foreach (var student in this.studentsList)
            {
                gangMedia += student.grades;
            }

            gangMedia /= 5;

            return gangMedia;
        }
    }
}
