using System.Collections.Generic;
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

        private readonly List<SquareMesh> squares;

        private readonly List<Vector3> vertexPositions;

        private readonly List<int> triangleIndexes;

        public MapMesh(SquareMatrix squareMatrix)
        {
            vertexPositions = new List<Vector3>();
            triangleIndexes = new List<int>();
            squares = new List<SquareMesh>();
            var vertexIndex = new IndexSequence(0);

            foreach (var square in squareMatrix)
            {
                var squareMesh = new SquareMeshFactory(vertexIndex).Create(square);
                vertexPositions.AddRange(squareMesh.VertexPositions);
                triangleIndexes.AddRange(squareMesh.TriangleIndexes);
                squares.Add(squareMesh);
            }
        }
    }
}