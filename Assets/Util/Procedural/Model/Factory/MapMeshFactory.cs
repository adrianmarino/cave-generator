using System;
using System.Collections.Generic;
using UnityEngine;

namespace Util.Procedural
{
    public static class MapMeshFactory
    {
        public static IMesh Create(SquareMatrix squareMatrix)
        {
            var indexSequence = new IndexSequence(0);
            var meshes = new List<IMesh>();

            foreach (var square in squareMatrix)
                meshes.Add(CreateSquare(square, indexSequence));

            return new Mesh(meshes);
        }

        private static IMesh CreateSquare(Square square, IndexSequence indexSequence)
        {
            switch (square.Configuration)
            {
                case 0:
                    return new Mesh();

                #region One edge nodes...
                case 1:
                    return CreateMesh(
                        indexSequence,
                        square.CentreLeft, square.CentreBottom, square.BottomLeft
                    );
                case 2:
                    return CreateMesh(indexSequence, square.BottomRight, square.CentreBottom, square.CentreRight);
                case 4:
                    return CreateMesh(indexSequence, square.TopRight, square.CentreRight, square.CentreTop);
                case 8:
                    return CreateMesh(indexSequence, square.TopLeft, square.CentreTop, square.CentreLeft);
                #endregion
                
                #region Two edge nodes...
                // Vertical
                case 6:
                    return CreateMesh(indexSequence, square.CentreTop, square.TopRight, square.BottomRight, square.CentreBottom);
                case 9:
                    return CreateMesh(indexSequence, square.TopLeft, square.CentreTop, square.CentreBottom, square.BottomLeft);

                // Horizontal
                case 3:
                    return CreateMesh(indexSequence, square.CentreRight, square.BottomRight, square.BottomLeft, square.CentreLeft);
                case 12:
                    return CreateMesh(indexSequence, square.TopLeft, square.TopRight, square.CentreRight, square.CentreLeft);

                // Diagonal
                case 5:
                    return CreateMesh(
                        indexSequence, 
                        square.CentreTop, square.TopRight, 
                        square.CentreRight, square.CentreBottom, 
                        square.BottomLeft, square.CentreLeft
                    );
                case 10:
                    return CreateMesh(
                        indexSequence, 
                        square.TopLeft, square.CentreTop, 
                        square.CentreRight, square.BottomRight, 
                        square.CentreBottom, square.CentreLeft
                    );
                #endregion

                #region Three edge nodes...
                case 7:
                    return CreateMesh(
                        indexSequence, 
                        square.CentreTop, square.TopRight, square.BottomRight, 
                        square.BottomLeft, square.CentreLeft
                    );
                case 11:
                    return CreateMesh(
                        indexSequence, 
                        square.TopLeft, square.CentreTop, square.CentreRight, 
                        square.BottomRight, square.BottomLeft
                    );
                case 13:
                    return CreateMesh(
                        indexSequence, 
                        square.TopLeft, square.TopRight, square.CentreRight, 
                        square.CentreBottom, square.BottomLeft
                    );
                case 14:
                    return CreateMesh(
                        indexSequence, 
                        square.TopLeft, square.TopRight, square.BottomRight, 
                        square.CentreBottom, square.CentreLeft
                    );
                #endregion

                #region Four edge nodes...
                case 15:
                    return CreateMesh(
                        indexSequence,
                        true,
                        square.TopLeft, square.TopRight, 
                        square.BottomRight, square.BottomLeft
                    );
                #endregion
                
                default:
                    throw new Exception("Not valid configuration value!");
            }
        }


        private static Mesh CreateMesh(IndexSequence indexSequence, params SquareNode[] nodes)
        {
            return CreateMesh(indexSequence, false, nodes);
        }

        private static Mesh CreateMesh(IndexSequence indexSequence, bool inner, params SquareNode[] nodes)
        {
            var vertices = new Dictionary<Vector3, Vertex>();
            var triangles = new List<Triangle>();

            // 1 triangle...
            if (nodes.Length >= 3)
                triangles.Add(CreateTriangle(nodes, vertices, indexSequence, inner, 0, 1, 2));

            // 2 triangles...
            if (nodes.Length >= 4)
                triangles.Add(CreateTriangle(nodes, vertices, indexSequence, inner, 0, 2, 3));

            // 3 triangles...
            if (nodes.Length >= 5)
                triangles.Add(CreateTriangle(nodes, vertices, indexSequence, inner, 0, 3, 4));
            
            // 4 triangles...
            if (nodes.Length >= 6)
                triangles.Add(CreateTriangle(nodes, vertices, indexSequence, inner, 0, 4, 5));

            return new Mesh(triangles);
        }

        private static Triangle CreateTriangle(
            IList<SquareNode> nodes, 
            IDictionary<Vector3, Vertex> vertices,
            IndexSequence indexSequence,
            bool inner,
            params int[] vertexIndex
        )
        {
            return new Triangle(
                GetVertex(vertices, nodes, indexSequence, vertexIndex[0]),
                GetVertex(vertices, nodes, indexSequence, vertexIndex[1]),
                GetVertex(vertices, nodes, indexSequence, vertexIndex[2]),
                inner
            );
        }

        private static Vertex GetVertex(
            IDictionary<Vector3, Vertex> vertices,
            IList<SquareNode> nodes,    
            IndexSequence indexSequence,
            int nodeIndex
        )
        {
            var nodePosition = nodes[nodeIndex].Position;

            if (vertices.ContainsKey(nodePosition)) 
                return vertices[nodePosition];

            var vertex = new Vertex(nodePosition, indexSequence.Next());
            vertices[nodePosition] = vertex;
            return vertex;
        }
    }
}