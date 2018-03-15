using System.Collections.Generic;
using System.Linq;

namespace Procedural.Model
{
    public class FullScanStrategy: IOutlineEdgeFactory
    {
        public IEnumerable<Edge> Build(IMesh mesh)
        {
            return  from vertex1 in mesh.ExternalVertices
                    from vertex2 in mesh.ExternalVertices
                    where !vertex1.Equals(vertex2)
                    where vertex1.makeUpOutlineEdge(vertex2)
                    select new Edge(vertex1, vertex2);
        }
    }
}