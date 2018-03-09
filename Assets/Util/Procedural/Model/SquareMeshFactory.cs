using System;
using System.Collections.Generic;
using System.Linq;

namespace Util.Procedural
{
    public class SquareMeshFactory
    {
        public SquareMesh Create(Square square)
        {
            switch (square.Configuration)
            {
                case 0:
                    return new SquareMesh();

                #region One edge nodes...
                case 1:
                    return CreateMesh(square.CentreBottom, square.BottomLeft, square.CentreLeft);
                case 2:
                    return CreateMesh(square.CentreRight, square.BottomRight, square.CentreBottom);
                case 4:
                    return CreateMesh(square.CentreTop, square.TopRight, square.CentreRight);
                case 8:
                    return CreateMesh(square.TopLeft, square.CentreTop, square.CentreLeft);
                #endregion
                
                #region Two edge nodes...
                // Vertical
                case 6:
                    return CreateMesh(square.CentreTop, square.TopRight, square.BottomRight, square.CentreBottom);
                case 9:
                    return CreateMesh(square.TopLeft, square.CentreTop, square.CentreBottom, square.BottomLeft);

                // Horizontal
                case 3:
                    return CreateMesh(square.CentreRight, square.BottomRight, square.BottomLeft, square.CentreLeft);
                case 12:
                    return CreateMesh(square.TopLeft, square.TopRight, square.CentreRight, square.CentreLeft);

                // Diagonal
                case 5:
                    return CreateMesh(square.CentreTop, square.TopRight, square.CentreRight, 
                        square.CentreBottom, square.BottomLeft, square.CentreLeft);
                case 10:
                    return CreateMesh(square.TopLeft, square.CentreTop, square.CentreRight,
                        square.BottomRight, square.CentreBottom, square.CentreLeft);
                #endregion

                #region Three edge nodes...
                case 7:
                    return CreateMesh(square.CentreTop, square.TopRight, square.BottomRight, 
                        square.BottomLeft, square.CentreLeft);
                case 11:
                    return CreateMesh(square.TopLeft, square.CentreTop, square.CentreRight, 
                        square.BottomRight, square.BottomLeft);
                case 13:
                    return CreateMesh(square.TopLeft, square.TopRight, square.CentreRight, 
                        square.CentreBottom, square.BottomLeft);
                case 14:
                    return CreateMesh(square.TopLeft, square.TopRight, square.BottomRight, 
                        square.CentreBottom, square.CentreLeft);
                #endregion

                #region Four edge nodes...
                case 15:
                    return CreateMesh(square.TopLeft, square.TopRight, square.BottomRight, square.BottomLeft);
                #endregion
                
                default:
                    throw new Exception("Not valid configuration value!");
            }
        }

        private SquareMesh CreateMesh(params SquareNode[] nodes)
        {
            var vertices = new Dictionary<int,Vertex>();
            var triangles = new List<Triangle>();
            
            // 1 triangle...
            if (nodes.Length >= 3)
            {
                triangles.Add(new Triangle(
                    GetVertex(vertices, nodes, 0),
                    GetVertex(vertices, nodes, 1),
                    GetVertex(vertices, nodes, 2)
                ));
            }

            // 2 triangles...
            if (nodes.Length >= 4)
            {
                triangles.Add(new Triangle(
                    GetVertex(vertices, nodes, 0),
                    GetVertex(vertices, nodes, 2),
                    GetVertex(vertices, nodes, 3)
                ));
            }

            // 3 triangles...
            if (nodes.Length >= 5)
            {
                triangles.Add(new Triangle(
                    GetVertex(vertices, nodes, 0),
                    GetVertex(vertices, nodes, 3),
                    GetVertex(vertices, nodes, 4)
                ));
            }
            
            // 4 triangles...
            if (nodes.Length >= 6)
            {
                triangles.Add(new Triangle(
                    GetVertex(vertices, nodes, 0),
                    GetVertex(vertices, nodes, 4),
                    GetVertex(vertices, nodes, 5)
                ));
            }

            return new SquareMesh(triangles);
        }

        private Vertex GetVertex(
            IDictionary<int, Vertex> vertices,
            IList<SquareNode> nodes,    
            int localIndex
        )
        {
            if (vertices.ContainsKey(localIndex)) 
                return vertices[localIndex];

            var vertex = new Vertex(nodes[localIndex].Position, vertexIndex.Next());
            vertices[localIndex] = vertex;
            return vertex;
        }

        readonly IndexSequence vertexIndex;

        public SquareMeshFactory(IndexSequence vertexIndex)
        {
            this.vertexIndex = vertexIndex;
        }
    }
}