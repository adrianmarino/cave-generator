using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Procedural.Model
{
    public static class WallMeshFactory
    {
        public static IMesh Create(IEnumerable<Edge> edges, float height)
        {
            var sequence = new IndexSequence(0);
            var meshes = edges.Select(edge => Create(edge, height, sequence)).ToList();
            return new Mesh(meshes);
        }

        public static IMesh Create(Edge edge, float height, IndexSequence sequence)
        {
            var leftUp = CreateLeftUpVertex(edge, sequence);
            var rightUp = CreateRightUpVertex(edge, sequence);
            
            var leftDown = CreateLeftDownVertex(edge, height, sequence);
            var rightDown = CreateRightDownVertex(edge, height, sequence);

            return new Mesh(
                new Triangle(leftUp, leftDown, rightUp), 
                new Triangle(rightUp, leftDown, rightDown)
            );
        }
        
        private static Vertex CreateLeftUpVertex(Edge edge, IndexSequence sequence)
        {
            return new Vertex(edge.Vertex1.Position, sequence.Next());
        }

        private static Vertex CreateLeftDownVertex(Edge edge, float height, IndexSequence sequence)
        {
            return new Vertex(edge.Vertex1.Position - Vector3.up * height, sequence.Next());
        }

        private static Vertex CreateRightUpVertex(Edge edge, IndexSequence sequence)
        {
            return new Vertex(edge.Vertex2.Position, sequence.Next());
        }

        private static Vertex CreateRightDownVertex(Edge edge, float height, IndexSequence sequence)
        {
            return new Vertex(edge.Vertex2.Position - Vector3.up * height, sequence.Next());   
        }
    }
}