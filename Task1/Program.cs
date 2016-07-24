using System;

namespace Task1
{
    internal class Program
    {
        private static void Main()
        {
            var a = new NullType<int>(10);
            
            Console.WriteLine(a.Value);

            var b = new NullType<int>();
            b = 20;

            Console.WriteLine(b.Value);

            var c = a + b;

            Console.WriteLine(c.Value);

            Console.ReadLine();
        }
    }
}
