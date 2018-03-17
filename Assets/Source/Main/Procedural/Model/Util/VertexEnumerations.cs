using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Procedural.Model {
    public static class VertexUtil {
        public static IOrderedEnumerable<Vertex> sorByIndex(this IEnumerable<Vertex> vertices) {
            return vertices.OrderBy(vertex => vertex.Index);
        }

        public static IEnumerable<Vector3> Positions(this IEnumerable<Vertex> vertices) {
            return vertices.Select(it => it.Position);
        }

        public static IEnumerable<int> Indexes(this IEnumerable<Vertex> vertices) {
            return vertices.Select(it => it.Index);
        }
    }
}