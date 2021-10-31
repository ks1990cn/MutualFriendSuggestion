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
        BFS _bfs;
        public MFSOutput(BFS bFS)
        {
            
            mutualFriends = bFS!=null ? bFS._mutualFriends: throw new NullReferenceException();
            this._bfs = bFS;
        }

        public void mutualFriendsList(int s, Dictionary<int, Person> people)
        {

            _bfs.BFSTraversal(s);
            foreach (var item in mutualFriends)
            {
                Console.Write(item + " ");
            }

        }
    }
}
