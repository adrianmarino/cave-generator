using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util.Procedural
{
    public static class MeshFactory
    {
        public static Mesh Create(SquareMatrix squareMatrix)
        {
            var vertexIndex = new IndexSequence(0);

            var vertices = new List<Vector3>();
            var triangles = new List<int>();

            foreach (var square in squareMatrix)
            {
                var factory = new SquareMeshFactory(vertexIndex);
                var squareMesh = factory.Create(square);

                vertices.AddRange(squareMesh.Vertices
                    .Select(it => it.Position));
                
                triangles.AddRange(squareMesh.Triangles
                    .SelectMany(it =>it.Vertices)
                    .Select(it => it.Index));
            }

            var mesh = new Mesh
            {
                vertices = vertices.ToArray(),
                triangles = triangles.ToArray()
            };
            mesh.RecalculateNormals();
            return mesh;
        }

    }
}