using System.Collections.Generic;
using UnityEngine;

namespace Util.Procedural
{
    public class WallsMesh: IMesh
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
        
        #region Attributes
        
        private readonly List<Vector3> vertexPositions;

        private readonly List<int> triangleIndexes;

        private readonly List<WallMesh> walls;

        #endregion
        
        public WallsMesh(IEnumerable<Edge> edges, float height)
        {
            vertexPositions = new List<Vector3>();
            triangleIndexes = new List<int>();
            foreach (var edge in edges)
            { 
                var startIndex = vertexPositions.Count;
                var wall = new WallMesh(edge, height, startIndex);
                vertexPositions.AddRange(wall.VertexPositions);
                triangleIndexes.AddRange(wall.TriangleIndexes);
            }
        }
    }
}