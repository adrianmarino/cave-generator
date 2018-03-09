using System.Collections.Generic;
using UnityEngine;

namespace Util.Procedural
{
    public class SquareMesh
    {
        #region Properties

        public IList<Triangle> Triangles { get; private set; }
        
        public IEnumerable<Vertex> Vertices { get; private set; }
        
        public IEnumerable<Vector3> VertexPositions { get; private set; }
        
        public IEnumerable<int> TriangleIndexes { get; private set; }   

        #endregion
     
        #region Constructors
        
        public SquareMesh(IList<Triangle> triangles)
        {
            Triangles = triangles;
            Vertices = Triangle.VerticesFrom(triangles);
            VertexPositions = Vertex.PositionsFrom(Vertices);
            TriangleIndexes = Triangle.IndexesFrom(triangles);
        }

        public SquareMesh() : this(new List<Triangle>())
        {
        }

        #endregion
    }
}