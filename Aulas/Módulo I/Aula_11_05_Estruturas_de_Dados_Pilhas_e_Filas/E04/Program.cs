using System.Collections;
using System;

namespace E04
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue row = new Queue(),
                reorderedRow = new Queue();

            row.Enqueue('T');
            row.Enqueue(true);
            row.Enqueue(false);
            row.Enqueue("Trop");
            row.Enqueue(1);
            row.Enqueue(7.6);

            int count = 0;

            foreach (var item in row)
            {
                if (count >= 3)
                    reorderedRow.Enqueue(item);
                count++;
            }

            reorderedRow.Enqueue(false);
            reorderedRow.Enqueue('T');
            reorderedRow.Enqueue(true);

            foreach (var item in reorderedRow)
                Console.WriteLine(item);
        }
    }
}
