using FlowAlgorithm.Structures;

namespace FlowAlgorithm.Algorithms
{
    internal class ConnectivityAlgorithm
    {
        public static int Solve(Graph G)
        {
            int MinMaxFlow = int.MaxValue, MaxFlow, s = 0;
            Network network;

            if (G.GetSize() <= 1) return 0;

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
