using FlowAlgorithm.Algorithms;
using FlowAlgorithm.Structures;

public class Program
{
    public static void Main(string[] args)
    {
        string workingDirectory = Environment.CurrentDirectory;       

        

        if (args.Length==1)
        {
            StreamWriter writer = new StreamWriter(workingDirectory + @"\output.txt");
            var path = args[0];

            var graph = new Graph(path);

            var result = ConnectivityAlgorithm.Solve(graph);

            Console.WriteLine($"Spojnosc krawedziowa podanego grafu wynosi {result}.");
            writer.WriteLine(result);
            writer.Flush();            
        }
        else
        {
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            StreamWriter writer = new StreamWriter(projectDirectory + @"\output.txt");
            DirectoryInfo d = new DirectoryInfo(projectDirectory);


            string[] fileEntries = Directory.GetFiles(projectDirectory + @"\Tests");

            foreach (string path in fileEntries)
            {
                var graph = new Graph(path);

                var result = ConnectivityAlgorithm.Solve(graph);

                Console.WriteLine($"Spójność krawędziowa grafu {Path.GetFileName(path)} wynosi {result}.");

                writer.WriteLine(Path.GetFileName(path)+ ": " + result);
                writer.Flush();
            }
        }
        Console.ReadKey();
        
    }
}
