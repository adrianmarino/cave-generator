using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using UnityEngine;

namespace Util.Procedural
{
    public class MapMesh: IMesh
    {
        public Mesh asMesh()
        {
            var mesh = new Mesh
            {
                vertices = vertexPositions.ToArray(),
                triangles = triangleIndexes.ToArray()
            };
            mesh.RecalculateNormals();
            return mesh;
        }

        public IList<Edge> OutlineEdges
        {
            get
            {
                return outEdges ?? (outEdges = GetOutlineEdges());
            }
        }

        private IList<Edge> GetOutlineEdges()
        {
            var checkedVertices = new HashSet<Vertex>();
            return outEdges = (
                from vertex1 in vertices
                from triangle in vertex1.Triangles
                from vertex2 in triangle.Vertices
                where vertex1 != vertex2 &&
                      !checkedVertices.Contains(vertex2) &&
                      vertex1.makeUpOutlineEdge(vertex2)
                select new Edge(vertex1, vertex2)
            ).ToList();
        }

        #region Attributes

        private readonly List<Vertex> vertices;
        
        private readonly List<Vector3> vertexPositions;

        private readonly List<int> triangleIndexes;

        private IList<Edge> outEdges;

        #endregion

        #region Constructors

        public MapMesh(SquareMatrix squareMatrix)
        {
            vertices = new List<Vertex>();
            vertexPositions = new List<Vector3>();
            triangleIndexes = new List<int>();
            var vertexIndex = new IndexSequence(0);

            foreach (var square in squareMatrix)
            {
                var squareMesh = new SquareMeshFactory(vertexIndex).Create(square);

                vertices.AddRange(squareMesh.Vertices);
                vertexPositions.AddRange(squareMesh.VertexPositions);
                triangleIndexes.AddRange(squareMesh.TriangleIndexes);
            }
        }

        #endregion
    }
}