using System;
using MFSEngine.Logic;
using MFSEngine.Models;

namespace MFSEngine
{
    class MFSOutput
    {
        ITraversal _bfs;
        public MFSOutput(ITraversal bFS)
        {
            this._bfs = bFS;
        }

        public void mutualFriendsList(MFSGraph connections, int searchItem)
        {
            foreach (var item in _bfs.Traverse(connections, searchItem))
            {
                Console.Write(item + " ");
            }
        }
    }
}
