using System.Collections.Generic;
using UnityEngine;

namespace Util.Procedural
{
    public class WallMesh
    {
        public IEnumerable<Vector3> VertexPositions
        {
            get { return Vertex.PositionsFrom(Triangle.VerticesFrom(Triangles)); }
        }

        public IEnumerable<int> TriangleIndexes
        {
            get { return Triangle.IndexesFrom(Triangles); }
        }

        public IList<Triangle> Triangles { get; private set; }
        
        public WallMesh(Edge edge, float height, int index)
        {
            var vertex1Up = new Vertex(edge.Vertex1.Position, index);
            var vertex2Up = new Vertex(edge.Vertex1.Position, index++);

            var vertex1Down = new Vertex(edge.Vertex1.Position - Vector3.up * height, index++);
            var vertex2Down = new Vertex(edge.Vertex1.Position - Vector3.up * height, index++);

            Triangles = new List<Triangle>
            {
                new Triangle(vertex1Up, vertex2Up, vertex2Down),
                new Triangle(vertex1Up, vertex1Down, vertex2Up)
            };
        }
    }
}