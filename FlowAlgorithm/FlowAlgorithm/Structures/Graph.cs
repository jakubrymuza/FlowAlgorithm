namespace FlowAlgorithm.Structures
{
    internal class Graph
    {
        protected bool[,] _adjacencyMatrix;
        protected int _size;

        internal Graph(string path)
        {
            string fileText = File.ReadAllText(path);
            string[] lines = fileText.Split('\n');

            _size = int.Parse(lines[0]);

            _adjacencyMatrix = new bool[_size, _size];

            for (int i = 1; i < lines.Length; i++)
            {
                var verts = lines[i].Split(" ");
                _adjacencyMatrix[int.Parse(verts[0]) - 1, int.Parse(verts[1]) - 1] = true;
            }
        }

        internal int GetSize() => _size;


        internal bool HasEdge(int x, int y) => _adjacencyMatrix[x, y];

        internal virtual IEnumerator<Edge> Edges()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = i; j < _size; j++)
                    if (_adjacencyMatrix[i, j])
                        yield return new Edge(i, j);
            }
        }

        internal virtual IEnumerator<Edge> Neighbors(int x)
        {
            for (int i = 0; i < _size; i++)
                if (_adjacencyMatrix[x, i])
                    yield return new Edge(x, i);
        }


        protected Graph(int size)
        {
            _size = size;
            _adjacencyMatrix = new bool[_size, _size];
        }


    }
}