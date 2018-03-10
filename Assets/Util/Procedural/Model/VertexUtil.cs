using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util.Procedural
{
    public static class VertexUtil
    {
        public  static IOrderedEnumerable<Vertex> sorByIndex(IEnumerable<Vertex> vertices)
        {
            return vertices.OrderBy(vertex => vertex.Index);
        }
        
        public static IEnumerable<Vector3> PositionsFrom(IEnumerable<Vertex> vertices)
        {
            return vertices.Select(it => it.Position);
        }
        
        public static IEnumerable<int> IndexFrom(IEnumerable<Vertex> vertices)
        {
            return vertices.Select(it => it.Index);
        }

    }
}