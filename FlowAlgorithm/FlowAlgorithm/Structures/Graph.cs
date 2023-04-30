using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowAlgorithm.Structures
{
    internal class Graph : IEnumerable
    {        
        public IEnumerator GetEnumerator() // po wierzchołkach ma być
        {
            for (int index = 0; index < 10; index++)
            {
                yield return index;
            }
        }
    }
}