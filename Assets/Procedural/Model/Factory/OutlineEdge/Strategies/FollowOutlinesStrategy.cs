using System.Collections.Generic;
using System.Linq;
using Util;

namespace Procedural.Model
{
    public class FollowOutlinesStrategy : IOutlineEdgeFactory
    {
        public IList<Edge> build(IMesh mesh)
        {
            return mesh
                .ExternalVertices
                .WhereNot(checkedVertices.Contains)
                .Aggregate(new List<Edge>(), (edges, Vertex) => {

            });
        }
      
        readonly IList<Vertex> checkedVertices = new List<Vertex>();

        public FollowOutlinesStrategy()
        {
            checkedVertices = new List<Vertex>();
        }
    }
}