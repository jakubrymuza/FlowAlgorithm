using FlowAlgorithm.Algorithms;
using FlowAlgorithm.Structures;
namespace FlowAlgorithm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StreamWriter writer = new("./output.txt");

            foreach (var path in args)
            {
                var graph = new Graph(path);

                var result = ConnectivityAlgorithm.Solve(graph);

                Console.WriteLine($"Spójność krawędziowa grafu {path} wynosi {result}.");
                writer.WriteLine($"Spójność krawędziowa grafu {path} wynosi {result}.");
                writer.Flush();
            }

            Console.WriteLine("Enter enter to continue");
            Console.ReadLine();

        }
    }
}
