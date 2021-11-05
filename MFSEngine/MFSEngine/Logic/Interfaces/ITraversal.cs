
using System.Collections.Generic;
using MFSEngine.Models;


namespace MFSEngine.Logic
{
public interface ITraversal
{
     IEnumerable<int> Traverse(MFSGraph g, int endPoint);
}
}