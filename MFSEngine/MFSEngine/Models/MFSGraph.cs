using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSEngine.Models
{
    public class MFSGraph
    {
        private int v;

        public int _V
        {
            get { return v; }
            set { v = value; }
        }

        private LinkedList<int>[] adj;

        public LinkedList<int>[] _adj
        {
            get { return adj; }
            set { adj = value; }
        }
        private LinkedList<int> list;
        // Function to add an edge into the graph
        public void AddEdge(int v, int w)
        {
            adj[v].AddLast(w);
            adj[w].AddLast(v);
        }
        public MFSGraph(int v)
        {
            adj = new LinkedList<int>[v];
            list = new LinkedList<int>();
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new LinkedList<int>();
            }
            this.v = v;
        }
    }
}
