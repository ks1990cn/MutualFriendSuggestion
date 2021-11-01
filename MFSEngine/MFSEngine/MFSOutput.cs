using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSEngine
{
    class MFSOutput
    {
        private LinkedList<int> mutualFriends;
        private int source;
        private Dictionary<int, Person> people;
        BFS _bfs;
        public MFSOutput(BFS bFS,int s, Dictionary<int, Person> people)
        {
            
            mutualFriends = bFS!=null ? bFS._mutualFriends: throw new NullReferenceException();
            this._bfs = bFS;
            this.source = s;
            this.people = people;
        }

        public void mutualFriendsList()
        {

            _bfs.BFSTraversal(this.source);
            foreach (var item in this.mutualFriends)
            {
                Console.Write(item + " ");
            }

        }
    }
}
