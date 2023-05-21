// See https://aka.ms/new-console-template for more information
using TestsGenerator;
namespace TestsGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string RSpath = "C:\\Users\\rafci\\Desktop\\FlowAlgorithm\\FlowAlgorithm\\FlowAlgorithm\\Tests\\Cliques\\";
            if (args.Length == 0)
            {

                Clique.GenerateCliques(new() { 1, 2, 3, 4, 5, 6 }, RSpath);

                Clique.GenerateClique(7, RSpath);
            }
            else
            {
                for (int i = 0; i < args.Length; i += 2)
                {
                    if (args[i] == "c" && i + 1 < args.Length && int.TryParse(args[i + 1], out _))
                    {
                        Clique.GenerateClique(int.Parse(args[i + 1]), "");
                    }
                }
            }
        }
    }
}