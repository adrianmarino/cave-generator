using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Procedural.Model {
    public class MapMeshFactory {
        public IMesh Create(SquareMatrix squareMatrix) {
            Reset();
            return new Mesh(squareMatrix.Select(CreateSquare));
        }

        private IMesh CreateSquare(Square square) {
            switch (square.Configuration){
                case 0:
                    return new Mesh();

                #region One edge nodes...

                case 1:
                    return CreateMesh(square.CentreLeft, square.CentreBottom, square.BottomLeft);
                case 2:
                    return CreateMesh(square.BottomRight, square.CentreBottom, square.CentreRight);
                case 4:
                    return CreateMesh(square.TopRight, square.CentreRight, square.CentreTop);
                case 8:
                    return CreateMesh(square.TopLeft, square.CentreTop, square.CentreLeft);

                #endregion

                #region Two edge nodes...

                // Vertical
                case 6:
                    return CreateMesh(square.CentreTop, square.TopRight, square.BottomRight,
                        square.CentreBottom);
                case 9:
                    return CreateMesh(square.TopLeft, square.CentreTop, square.CentreBottom,
                        square.BottomLeft);

                // Horizontal
                case 3:
                    return CreateMesh(square.CentreRight, square.BottomRight, square.BottomLeft,
                        square.CentreLeft);
                case 12:
                    return CreateMesh(square.TopLeft, square.TopRight, square.CentreRight,
                        square.CentreLeft);

                // Diagonal
                case 5:
                    return CreateMesh(
                        square.CentreTop, square.TopRight,
                        square.CentreRight, square.CentreBottom,
                        square.BottomLeft, square.CentreLeft
                    );
                case 10:
                    return CreateMesh(
                        square.TopLeft, square.CentreTop,
                        square.CentreRight, square.BottomRight,
                        square.CentreBottom, square.CentreLeft
                    );

                #endregion

                #region Three edge nodes...

                case 7:
                    return CreateMesh(
                        square.CentreTop, square.TopRight, square.BottomRight,
                        square.BottomLeft, square.CentreLeft
                    );
                case 11:
                    return CreateMesh(
                        square.TopLeft, square.CentreTop, square.CentreRight,
                        square.BottomRight, square.BottomLeft
                    );
                case 13:
                    return CreateMesh(
                        square.TopLeft, square.TopRight, square.CentreRight,
                        square.CentreBottom, square.BottomLeft
                    );
                case 14:
                    return CreateMesh(
                        square.TopLeft, square.TopRight, square.BottomRight,
                        square.CentreBottom, square.CentreLeft
                    );

                #endregion

                #region Four edge nodes...

                case 15:
                    return CreateMesh(
                        true,
                        square.TopLeft, square.TopRight,
                        square.BottomRight, square.BottomLeft
                    );

                #endregion

                default:
                    throw new Exception("Not valid configuration value!");
            }
        }

        private Mesh CreateMesh(params SquareNode[] nodes) {
            return CreateMesh(false, nodes);
        }

        private Mesh CreateMesh(bool inner, params SquareNode[] nodes) {
            var triangles = new List<Triangle>();

            // 1 triangle...
            if (nodes.Length >= 3)
                triangles.Add(CreateTriangle(nodes, inner, 0, 1, 2));

            // 2 triangles...
            if (nodes.Length >= 4)
                triangles.Add(CreateTriangle(nodes, inner, 0, 2, 3));

            // 3 triangles...
            if (nodes.Length >= 5)
                triangles.Add(CreateTriangle(nodes, inner, 0, 3, 4));

            // 4 triangles...
            if (nodes.Length >= 6)
                triangles.Add(CreateTriangle(nodes, inner, 0, 4, 5));

            return new Mesh(triangles);
        }

        private Triangle CreateTriangle(
            IList<SquareNode> nodes,
            bool inner,
            params int[] vertexIndex
        ) {
            return new Triangle(
                GetVertex(nodes, vertexIndex[0]),
                GetVertex(nodes, vertexIndex[1]),
                GetVertex(nodes, vertexIndex[2]),
                inner
            );
        }

        private Vertex GetVertex(IList<SquareNode> nodes, int nodeIndex) {
            var nodePosition = nodes[nodeIndex].Position;

            if (vertices.ContainsKey(nodePosition))
                return vertices[nodePosition];

            var vertex = new Vertex(nodePosition, indexSequence.Next());
            vertices[nodePosition] = vertex;
            return vertex;
        }

        private void Reset() {
            indexSequence = new IndexSequence(0);
            vertices = new Dictionary<Vector3, Vertex>();
        }

        private IDictionary<Vector3, Vertex> vertices;

        private IndexSequence indexSequence;
    }
}