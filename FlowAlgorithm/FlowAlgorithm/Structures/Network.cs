namespace FlowAlgorithm.Structures
{
    internal class Network : Graph
    {
        private int[,] _capacityMatrix;
        private int[,] _flowMatrix;

        internal Network(int size, Graph graph) : base(size)
        {
            _capacityMatrix = new int[_size, _size];
            _flowMatrix = new int[_size, _size];
        }

        internal Network(Graph graph) : base(graph.GetSize())
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                    if (graph.HasEdge(i, j))
                    {
                        _adjacencyMatrix[i, j] = true;
                        _adjacencyMatrix[j, i] = true;
                    }
            }


            _capacityMatrix = new int[_size, _size];
            _flowMatrix = new int[_size, _size];

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_adjacencyMatrix[i, j])
                        _capacityMatrix[i, j] = 1;
                }
            }

        }

        internal override IEnumerator<NetworkEdge> Edges()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                    if (_adjacencyMatrix[i, j])
                        yield return new NetworkEdge(i, j, _capacityMatrix[i, j], _flowMatrix[i, j]);
            }
        }

        internal override IEnumerable<NetworkEdge> Neighbors(int x)
        {
            for (int i = 0; i < _size; i++)
                if (_adjacencyMatrix[x, i])
                    yield return new NetworkEdge(x, i, _capacityMatrix[x, i], _flowMatrix[x, i]);
        }

        internal void UpdateFlow(int x, int y, int flow)
        {
            if (_adjacencyMatrix[x, y])
                _flowMatrix[x, y] = flow;

        }
    }
}
