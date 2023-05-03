using FlowAlgorithm.Structures;

namespace FlowAlgorithm.Algorithms
{
    internal class ConnectivityAlgorithm
    {
        public int Solve(Graph G)
        {
            int MinMaxFlow = 0;
            int s = 0;
            int MaxFlow;
            Network network;
            for(int t=1;t<G.GetSize();t++)
            {
                network = new Network(G);
                MaxFlow = FlowAlgorithm.Solve(network,s,t);
                MinMaxFlow = Math.Min(MaxFlow, MinMaxFlow);
            }
            return MinMaxFlow;
        }
    }
}
