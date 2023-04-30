using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAlgorithm.Structures
{
    internal class Network: Graph
    {

        // iteracja po krawedziach

        public IEnumerator GetEnumerator() // po krawędziach ma być
        {
            for (int index = 0; index < 10; index++)
            {
                yield return new NetworkEdge();
            }
        }

        // update krawedzi


        // sasiedzi

        NetworkEdge Neighbors(int Vertex)
        {
            throw new NotImplementedException();
        }
    }
}
