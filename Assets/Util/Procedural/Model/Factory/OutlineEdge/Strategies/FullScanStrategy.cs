using System.Collections.Generic;
using System.Linq;

namespace Util.Procedural
{
    public class FullScanStrategy: IOutlineEdgeFactory
    {
        public IList<Edge> build(IMesh mesh)
        {
            var vertices = TriangleUtil.VerticesFrom(mesh.Triangles.Where(it => !it.Inner)).Distinct();

            return (from vertex1 in vertices from vertex2 in vertices where !vertex1.Equals(vertex2) where vertex1.makeUpOutlineEdge(vertex2) select new Edge(vertex1, vertex2)).ToList();
        }
    }
}