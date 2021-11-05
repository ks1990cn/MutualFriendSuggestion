using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSEngine.Models;

namespace MFSEngine
{
    class BFS: ITraversal
    {
        private int _V;
        //Adjacency Lists
        LinkedList<int>[] _adj;
        private LinkedList<int> list;
        private LinkedList<int> sourcePersonFriends;
        private LinkedList<int> mutualFriends;
        public LinkedList<int> _mutualFriends
        {
            get { return mutualFriends; }
            set { mutualFriends = value; }
        }

        public BFS()
        {
            mutualFriends = new LinkedList<int>();
            list = new LinkedList<int>();
        }

        // Prints BFS traversal from a given source s
        public void Traverse(MFSGraph connectedGraph, int s)
        {
            mutualFriends.Clear();
            list.Clear();

            _adj = connectedGraph?._adj ?? throw new NullReferenceException();
            _V = connectedGraph?._V ?? throw new NullReferenceException();

            // Mark all the vertices as not visited(By default set as false)
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;

            // Create a queue for BFS
            LinkedList<int> queue = new LinkedList<int>();

            // Mark the current node as visited and enqueue it
            visited[s] = true;
            sourcePersonFriends = _adj[s];
            foreach (var val in sourcePersonFriends)
            {

                if (!visited[val])
                {
                    visited[val] = true;
                    queue.AddLast(val);
                }

            }
            while (queue.Any())
            {
                // Dequeue a vertex from queue and print it
                s = queue.First();
                queue.RemoveFirst();
                // Get all adjacent vertices of the dequeued vertex s. If a adjacent has not been visited, 
                // then mark it visited and enqueue it
                list = _adj[s];
                foreach (var val in list)
                {

                    if (!visited[val])
                    {
                        visited[val] = true;
                        mutualFriends.AddLast(val);
                    }
                }
            }
        }
    }
}
