using System.Collections.Generic;
using System.Linq;

namespace Util.Procedural
{
    public static class TriangleUtil
    {
        public static IEnumerable<Vertex> VerticesFrom(IEnumerable<Triangle> triangles)
        {
            return triangles.SelectMany(it => it.Vertices);
        }
    }
}