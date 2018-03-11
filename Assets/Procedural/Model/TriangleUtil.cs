using System.Collections.Generic;
using System.Linq;
using Util;

namespace Procedural.Model
{
    public static class TriangleUtil
    {
        public static IEnumerable<Vertex> DistinctVertices(this IEnumerable<Triangle> triangles)
        {
            return triangles.Vertices().Distinct();
        }

        public static IEnumerable<Vertex> Vertices(this IEnumerable<Triangle> triangles)
        {
            return triangles.SelectMany(it => it.Vertices);
        }

        public static IEnumerable<Triangle> NonInner(this IEnumerable<Triangle> triangles) {
            return triangles.WhereNot(it => it.Inner);
        }
    }
}