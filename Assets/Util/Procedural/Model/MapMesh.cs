using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util.Procedural
{
    public class MapMesh
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

        private readonly IList<SquareMesh> squares;

        private readonly IList<Vector3> vertexPositions;

        private readonly IList<int> triangleIndexes;

        public MapMesh(SquareMatrix squareMatrix)
        {
            vertexPositions = new List<Vector3>();
            triangleIndexes = new List<int>();
            squares = new List<SquareMesh>();
            var vertexIndex = new IndexSequence(0);

            foreach (var square in squareMatrix)
            {
                var squareMesh = new SquareMeshFactory(vertexIndex).Create(square);
                squareMesh.VertexPositions.ForEach(it => vertexPositions.Add(it));
                squareMesh.TriangleIndexes.ForEach(it => triangleIndexes.Add(it));
                squares.Add(squareMesh);
            }
        }
    }
}