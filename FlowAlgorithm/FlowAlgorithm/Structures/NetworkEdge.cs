namespace FlowAlgorithm.Structures
{
    internal class NetworkEdge : Edge
    {
        public int capacity;
        public int flow;

        internal NetworkEdge(int x, int y, int capacity, int flow) : base(x, y)
        {
            this.capacity = capacity;
            this.flow = flow;
        }
    }
}
