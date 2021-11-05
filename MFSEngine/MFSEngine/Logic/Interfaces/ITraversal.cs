
using System.Collections.Generic;
using MFSEngine.Models;

public interface ITraversal
{
     IEnumerable<int> Traverse(MFSGraph g, int endPoint);
}