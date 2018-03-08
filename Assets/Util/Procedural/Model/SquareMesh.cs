using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util.Procedural
{
    public class SquareMesh
    {
        public override string ToString()
        {
            return string.Format("Triangles: {0}", StringUtil.ToString(triangles));
        }

        public IList<Triangle> Triangles
        {
            get { return triangles; }
        }

        public IList<Vertex> Vertices
        {
            get { return Triangle.VerticesFrom(triangles).ToArray(); }
        }

        public Vector3[] VertexPositions
        {
            get { return Vertex.PositionsFrom(Vertices).ToArray(); }
        }

        public int[] TriangleIndexes
        {
            get { return Triangle.IndexesFrom(triangles).ToArray(); }
        }

        public readonly IList<Triangle> triangles;

        public readonly IList<Vertex> vertices;

        private readonly Vector3[] vertexPositions;

        private readonly int[] triangleIndexes;

        public SquareMesh() : this(new List<Triangle>())
        {
        }

        public SquareMesh(IList<Triangle> triangles)
        {
            this.triangles = triangles;
        }
    }
}