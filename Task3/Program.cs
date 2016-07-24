using System;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            var gr = new Graph(10, 45);
            
            for (var i = 0; i < gr.Count; i++)
            {
                for (var j = 0; j < gr.Count; j++)
                {
                    Console.Write("{0},", gr.Array[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("Graph is connected: {0}", gr.IsConnected());
            Console.WriteLine("Graph has cycles: {0}", gr.HasCycles());
            Console.WriteLine("Graph has Eulerian cycles: {0}", gr.HasEulerianCycles());
            Console.WriteLine("Graph has Eulerian path: {0}", gr.HasEulerianPath());

            Console.ReadLine();
        }
    }
}
