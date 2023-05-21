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
        public static void GenerateClique(List<int> VerticlesCounts, string path)
        {
            for(int i = 0; i < VerticlesCounts.Count; i++) 
            {
                GenerateClique(VerticlesCounts[i], path, i);
            }
        }
        private static void GenerateClique(int VerticlesCount, string path,int index)
        {
            using (StreamWriter writer =new($"{path}test{index}.txt"))
            {
                writer.WriteLine(VerticlesCount.ToString());

                for(int i=1;i<= VerticlesCount;i++)
                {
                    for(int j=i+1;j<= VerticlesCount;j++)
                    {
                        writer.WriteLine($"{i} {j}");
                    }
                }
            }
        }
    }
}
