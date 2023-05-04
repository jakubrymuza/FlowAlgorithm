using FlowAlgorithm.Algorithms;
using FlowAlgorithm.Structures;

public class Program
{
    public static void Main(string[] args)
    {
        var path = args[0];

        var graph = new Graph(path);

        var algorithm = new ConnectivityAlgorithm();

        var result = algorithm.Solve(graph);

        StreamWriter writer = new StreamWriter("output.txt");

        Console.WriteLine($"Spójność krawędziowa podanego grafu wynosi {result}.");
        writer.WriteLine(result);
    }
}
