using FlowAlgorithm.Algorithms;
using FlowAlgorithm.Structures;
using System.Diagnostics;

namespace FlowAlgorithm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StreamWriter writer = new("./output.txt");

            foreach(var path in args)
            {
                var graph = new Graph(path);

                Stopwatch stopwatch = new();
                stopwatch.Start();
                var result = ConnectivityAlgorithm.Solve(graph);
                stopwatch.Stop();

                double time = (double)stopwatch.ElapsedMilliseconds / 1000;

                lock (writer)
                {
                    Console.WriteLine($"Spójność krawędziowa grafu {path} wynosi {result}. Czas obliczeń: {time}s.");
                    writer.WriteLine($"Spójność krawędziowa grafu {path} wynosi {result}. Czas obliczeń: {time}s.");
                }   
            }

            writer.Flush();
            Console.WriteLine("Enter enter to continue");
            Console.ReadLine();

        }
    }
}
