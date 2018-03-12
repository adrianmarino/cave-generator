using System.Collections.Generic;
using System.Linq;
using Util;

namespace Procedural.Model
{
    public class FollowOutlinesStrategy : IOutlineEdgeFactory
    {
        public IEnumerable<Edge> build(IMesh mesh)
        {
            return null;
        }
      
        readonly IList<Vertex> checkedVertices = new List<Vertex>();

        public FollowOutlinesStrategy()
        {
            checkedVertices = new List<Vertex>();
        }
    }
}