using FlowAlgorithm.Algorithms;
using FlowAlgorithm.Structures;

public class Program
{
    public static void Main(string[] args)
    {
        if(args.Length==1)
        {
            var path = args[0];

            var graph = new Graph(path);

            var algorithm = new ConnectivityAlgorithm();

            Console.WriteLine($"Spójność krawędziowa podanego grafu wynosi {ConnectivityAlgorithm.Solve(graph)}.");
        }
        else
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            DirectoryInfo d = new DirectoryInfo(projectDirectory);


            string[] fileEntries = Directory.GetFiles(projectDirectory + @"\Tests");

            foreach (string path in fileEntries)
            {
                var graph = new Graph(path);

                Console.WriteLine($"Spójność krawędziowa grafu {Path.GetFileName(path)} wynosi {ConnectivityAlgorithm.Solve(graph)}.");
            }
        }
        
    }
}
