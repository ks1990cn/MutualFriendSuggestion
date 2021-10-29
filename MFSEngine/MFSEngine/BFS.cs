using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSEngine
{
    class BFS
    {
        private int _V;

        //Adjacency Lists
        LinkedList<int>[] _adj;

        private LinkedList<int> list;
        Person inititalPerson;
        public BFS(int V)
        {
            inititalPerson = null;
            
            _adj = new LinkedList<int>[V];
            list = new LinkedList<int>();
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new LinkedList<int>();
            }
            _V = V;
        }

        // Function to add an edge into the graph
        public void AddEdge(int v, int w)
        {
            _adj[v].AddLast(w);
            _adj[w].AddLast(v);
        }


        // Prints BFS traversal from a given source s
        public void BFSTraversal(int s, Dictionary<int, Person> people)
        {

            // Mark all the vertices as not
            // visited(By default set as false)
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;

            // Create a queue for BFS
            LinkedList<int> queue = new LinkedList<int>();

            // Mark the current node as
            // visited and enqueue it
            visited[s] = true;
            queue.AddLast(s);

            //Initial/Current Source
            int initialSource = s;
            inititalPerson=people[initialSource];
            while (queue.Any())
            {

                // Dequeue a vertex from queue
                // and print it
                
                s = queue.First();
                //  if (queue.First() != currentSource)
                Console.Write(s + " ");
                queue.RemoveFirst();

               
                // Get all adjacent vertices of the
                // dequeued vertex s. If a adjacent
                // has not been visited, then mark it
                // visited and enqueue it
                
                list = _adj[s];
                foreach (var val in list)
                {
                    var currentNetworkPerson = people[val];
                    if (!visited[val] && Nodecomparision(inititalPerson,currentNetworkPerson))
                    {
                        visited[val] = true;
                        queue.AddLast(val);
                    }

                }

            }
        }

        //Node Comparision
        public bool Nodecomparision(Person sourcePerson, Person mutualPerson)
        {
            if (sourcePerson.location==mutualPerson.location) return true;
            return false;
        }

    }
}
