using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph
    {
    }
    class Digraph<T> where T : IComparable<T>
    {
        public List<Vertex<T>> Vertices = new List<Vertex<T>>();

        public void AddVertex(Vertex<T> v)
        {
            Vertices.Add(v);
        }

 
        public List<Vertex<T>> TopologicalSort()
        {
            List<Vertex<T>> sorted = new List<Vertex<T>>();
            Queue<Vertex<T>> zeros = new Queue<Vertex<T>>();
            int vNum = this.Vertices.Count;                
            while (sorted.Count < vNum)
            {
                Vertex<T> currVertex;
                // all vertices with indegree 0 will be enqueued
                for (int ix = 0; ix < vNum; ix++)
                {
                    if (this.Vertices.ElementAt(ix).InDegree == 0)
                    {
                        // Checks to see if this element was already used
                        if (!(sorted.Contains(this.Vertices.ElementAt(ix)) || zeros.Contains(this.Vertices.ElementAt(ix))))
                        {
                            zeros.Enqueue(this.Vertices.ElementAt(ix));
                        }

                    }
                }

                currVertex = zeros.Dequeue();
                sorted.Add(currVertex);
                // subtract indegrees from rest of the list for the element that was taken out
                for (int ix = 0; ix < currVertex.Neighbors.Count; ++ix)
                {
                    Vertex<T> currNeighbor = currVertex.Neighbors.ElementAt(ix);
                    currNeighbor.InDegree = currNeighbor.InDegree - 1;
                }
            } 
            return sorted;
        }

    }
}

 
