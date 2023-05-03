using FlowAlgorithm.Algorithms;
using FlowAlgorithm.Structures;

public class Program
{
    public static void Main(string[] args)
    {
        var path = args[0];

        var graph = new Graph(path);

        var algorithm = new ConnectivityAlgorithm();

        Console.WriteLine($"Spójność krawędziowa podanego grafu wynosi {algorithm.Solve(graph)}.");
    }
}
