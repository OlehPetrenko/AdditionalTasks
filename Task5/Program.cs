using System;

namespace Task5
{
    internal class Program
    {
        private static void Main()
        {
            var myCollection = new Collection<string, Entry>();

            for (var i = 0; i < 100000; i++)
            {
                var temp = new Entry(i.ToString());
                myCollection.Add(temp.GetKey(), temp);
            }

            myCollection[12345].SetFlag(5, true);

            Console.WriteLine(myCollection["12345"].GetFlag(5));

            Console.ReadLine();
        }
    }
}
