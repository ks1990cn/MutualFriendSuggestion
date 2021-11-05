using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSEngine.Models;

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

        public void mutualFriendsList(MFSGraph connections,int searchItem)
        {
            _bfs.Traverse(connections,searchItem);
            foreach (var item in mutualFriends)
            {
                Console.Write(item + " ");
            }

        }
    }
}
