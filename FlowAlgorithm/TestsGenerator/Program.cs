// See https://aka.ms/new-console-template for more information
using TestsGenerator;
namespace TestsGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = @".\..\..\..\..\FlowAlgorithm\Tests\";
            var x = Directory.GetParent(path);
                   
            if (args.Length == 0)
            {

                Clique.GenerateCliques(new() { 1, 2, 3, 4, 5, 6 }, path+@"Cliques\");

                Clique.GenerateClique(7, path + @"Cliques\");

                RandomGraph.GenerateDenseRandoms(new() { 1, 2, 3, 4, 5, 6 }, path + @"Dense\");

                RandomGraph.GenerateDenseRandom(7, path + @"Dense\");

                RandomGraph.GenerateSparseRandoms(new() { 1, 2, 3, 4, 5, 6 }, path + @"Sparse\");

                RandomGraph.GenerateSparseRandom(7, path + @"Sparse\");
            }
            else
            {
                int vartexCount;
                for (int i = 0; i < args.Length; i += 2)
                {
                    if (i + 1 < args.Length && int.TryParse(args[i + 1], out vartexCount))
                    {
                        switch (args[i])
                        {
                            case "c":
                                Clique.GenerateClique(vartexCount, path + @"Cliques\");
                                break;
                            case "d":
                                RandomGraph.GenerateDenseRandom(vartexCount, path + @"Dense\");
                                break;
                            case "s":
                                RandomGraph.GenerateSparseRandom(vartexCount, path + @"Sparse\");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}