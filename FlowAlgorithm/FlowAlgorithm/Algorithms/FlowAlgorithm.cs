using FlowAlgorithm.Structures;

namespace FlowAlgorithm.Algorithms
{
    internal class FlowAlgorithm
    {
        public static int Solve(Network network, int s, int t)
        {
            int flow = 0;
            Queue<int> q = new();
            NetworkEdge[] prevTable;
            do
            {
                prevTable = new NetworkEdge[network.GetSize()];
                q.Clear();
                q.Enqueue(s);
                while (q.Count > 0)
                {
                    int curr = q.Dequeue(), neighbour;
                    foreach (NetworkEdge neighbourEdge in network.Neighbors(curr))
                    {
                        neighbour = neighbourEdge.y;
                        if (prevTable[neighbour] == null && neighbour != s && neighbourEdge.capacity > neighbourEdge.flow)
                        {
                            prevTable[neighbour] = neighbourEdge;
                            q.Enqueue(neighbour);
                        }
                    }
                }
                if (prevTable[t] != null)
                {
                    LinkedList<NetworkEdge> path = new();
                    int df = int.MaxValue;

                    NetworkEdge currEdge = prevTable[t];
                    path.AddFirst(currEdge);
                    df = Math.Min(df, currEdge.capacity - currEdge.flow);

                    while (currEdge.x != s)
                    {
                        currEdge = prevTable[currEdge.x];
                        path.AddFirst(currEdge);
                        df = Math.Min(df, currEdge.capacity - currEdge.flow);
                    }
                    foreach (NetworkEdge edge in path)
                    {
                        network.UpdateFlow(edge.x, edge.y, edge.flow + df);
                        network.UpdateFlow(edge.y, edge.x, edge.flow - df);
                    }
                    flow += df;
                }
            } while (prevTable[t] != null);
            return flow;
        }
    }
}
