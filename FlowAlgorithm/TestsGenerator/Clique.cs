using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator
{
    internal class Clique
    {
        private static readonly string fileName = "clique-";
        public static void GenerateCliques(List<int> VerticesCounts, string path)
        {
            
            for(int i = 0; i < VerticesCounts.Count; i++) 
            {
                GenerateClique(VerticesCounts[i], path);
            }
        }
        public static void GenerateClique(int VerticesCount, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using StreamWriter writer = new($"{path}{fileName}{VerticesCount}.txt");
            writer.WriteLine(VerticesCount.ToString());

            for (int i = 1; i <= VerticesCount; i++)
            {
                for (int j = i + 1; j <= VerticesCount; j++)
                {
                    writer.WriteLine($"{i} {j}");
                }
            }
        }
    }
}
