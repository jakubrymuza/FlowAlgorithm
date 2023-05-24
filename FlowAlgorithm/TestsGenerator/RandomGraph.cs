using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator
{
    internal class RandomGraph
    {
        private static readonly string randomFileName = "random-";

        static Func<int, int>   Dense = x => (int)(0.5 * x * x), 
                                Sparse = x => x;

        public static void GenerateDenseRandoms(List<int> VerticesCounts, string path)
        {

            for (int i = 0; i < VerticesCounts.Count; i++)
            {
                GenerateDenseRandom(VerticesCounts[i], path);
            }
        }
        public static void GenerateSparseRandoms(List<int> VerticesCounts, string path)
        {

            for (int i = 0; i < VerticesCounts.Count; i++)
            {
                GenerateSparseRandom(VerticesCounts[i], path);
            }
        }

        public static void GenerateDenseRandom(int VerticesCount, string path)
        {
            string fileName = randomFileName + "D-";

            int index = GetIndex(path, $"{fileName}{VerticesCount}-");


            var edges = GenerateRandom(VerticesCount, Dense, index);

            WriteOutput(VerticesCount, edges, $"{path}{fileName}{VerticesCount}-{index}.txt");
        }


        public static void GenerateSparseRandom(int VerticesCount, string path)
        {
            string fileName = randomFileName + "S-";

            int index = GetIndex(path, $"{fileName}{VerticesCount}-");


            var edges = GenerateRandom(VerticesCount, Sparse, index);

            WriteOutput(VerticesCount, edges, $"{path}{fileName}{VerticesCount}-{index}.txt");
        }

        private static int GetIndex(string path, string fileName)
        {
            int index = -1;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string p in Directory.GetFiles(path))
            {
                if (Path.GetFileName(p).StartsWith(fileName))
                {
                    int currIndex;
                    string fName = Path.GetFileName(p);
                    fName=fName.Substring(0,fName.Length-4);
                    if (int.TryParse(fName.Substring(fileName.Length), out currIndex))
                    {
                        index = index < currIndex ? currIndex : index;
                    }

                }
            }
            
            index++;
            return index;
        }

        private static void WriteOutput(int VerticesCount,List<Edge> edges,string path)
        {
            using StreamWriter writer = new(path);
            writer.WriteLine(VerticesCount.ToString());

            for (int i = 0; i < edges.Count; i++)
            {
                writer.WriteLine(edges[i]);
            }
        }


        public class Edge
        {

            public int _x;
            public int _y;
            public Edge(int x, int y)
            {
                _x = x;
                _y = y;
            }
            public override string ToString()
            {
                return $"{_x} {_y}";
            }
        }
        public static List<Edge> GenerateRandom(int VerticesCount, Func<int, int> EdgeRes, int index)
        {
            Random random = new Random(VerticesCount * index);
            List<Edge> resultEdges = new List<Edge>();
            int Edges = EdgeRes(VerticesCount);

            List<Edge> edges = Enumerable.Range(0, VerticesCount * VerticesCount).Select(x=>new Edge(1+x/VerticesCount,1+x%VerticesCount)).Where(e=>e._x<e._y).ToList();


            while (edges.Count!=0 && resultEdges.Count < Edges)
            {
                int i = random.Next(edges.Count);

                Edge edge = edges[i];

                edges.RemoveAt(i);

                resultEdges.Add(edge);                
            }
            resultEdges.Sort((e1, e2) =>
            {
                if (e1._x <= e2._x)
                {
                    if (e1._x == e2._x)
                    {
                        return e1._y < e2._y ? -1 : 1;
                    }
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
            return resultEdges;
        }
    }
}
