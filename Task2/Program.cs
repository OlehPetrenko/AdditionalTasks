using System;

namespace Task2
{
    internal class Program
    {
        private static void Main()
        {
            var sequence = new Sequence(1000000);

            sequence.FillRandom();

            Console.WriteLine(sequence.CountSequence());

            Console.ReadLine();
        }
    }
}
