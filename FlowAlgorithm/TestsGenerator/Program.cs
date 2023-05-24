// See https://aka.ms/new-console-template for more information
namespace TestsGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = @".\..\..\..\..\FlowAlgorithm\Tests\";

            if (args.Length == 0)
            {

                Clique.GenerateCliques(new() { 1, 2, 3, 4, 5, 6 }, path + @"Cliques\");

                Clique.GenerateClique(7, path + @"Cliques\");

                RandomGraph.GenerateDenseRandoms(new() { 1, 2, 3, 4, 5, 6 }, path + @"Dense\");

                RandomGraph.GenerateDenseRandom(7, path + @"Dense\");

                RandomGraph.GenerateSparseRandoms(new() { 1, 2, 3, 4, 5, 6 }, path + @"Sparse\");

                RandomGraph.GenerateSparseRandom(7, path + @"Sparse\");
            }
            else
            {
                for (int i = 0; i < args.Length; i += 2)
                {
                    if (i + 1 < args.Length && int.TryParse(args[i + 1], out int vertexCount))
                    {
                        switch (args[i])
                        {
                            case "c":
                                Clique.GenerateClique(vertexCount, path + @"Cliques\");
                                break;
                            case "d":
                                RandomGraph.GenerateDenseRandom(vertexCount, path + @"Dense\");
                                break;
                            case "s":
                                RandomGraph.GenerateSparseRandom(vertexCount, path + @"Sparse\");
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