using FlowAlgorithm.Algorithms;
using FlowAlgorithm.Structures;

public class Program
{
    public static void Main(string[] args)
    {
        StreamWriter writer = new StreamWriter("./output.txt");

        foreach (var path in args)
        {
            var graph = new Graph(path);

            var result = ConnectivityAlgorithm.Solve(graph);

            Console.WriteLine($"Spójność krawędziowa grafu {path} wynosi {result}.");
            writer.WriteLine($"Spójność krawędziowa grafu {path} wynosi {result}.");
            writer.Flush();
        }

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();

    }
}
