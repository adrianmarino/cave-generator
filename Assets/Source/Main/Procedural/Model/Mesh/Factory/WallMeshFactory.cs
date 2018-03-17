using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Procedural.Model {
    public class WallMeshFactory {
        public IMesh Create(IEnumerable<Edge> edges, float height) {
            Reset();
            return new Mesh(edges.Select(edge => Create(edge, height)).ToList());
        }

        public IMesh Create(Edge edge, float height) {
            var leftUp = CreateLeftUpVertex(edge);
            var rightUp = CreateRightUpVertex(edge);

            var leftDown = CreateLeftDownVertex(edge, height);
            var rightDown = CreateRightDownVertex(edge, height);

            return new Mesh(
                new Triangle(leftUp, leftDown, rightUp),
                new Triangle(rightUp, leftDown, rightDown)
            );
        }

        private Vertex CreateLeftUpVertex(Edge edge) {
            return new Vertex(edge.VertexB.Position, indexSequence.Next());
        }

        private Vertex CreateLeftDownVertex(Edge edge, float height) {
            return new Vertex(edge.VertexB.Position - Vector3.up * height, indexSequence.Next());
        }

        private Vertex CreateRightUpVertex(Edge edge) {
            return new Vertex(edge.VertexA.Position, indexSequence.Next());
        }

        private Vertex CreateRightDownVertex(Edge edge, float height) {
            return new Vertex(edge.VertexA.Position - Vector3.up * height, indexSequence.Next());
        }

        private void Reset() {
            indexSequence = new IndexSequence(0);
        }

        private IndexSequence indexSequence;
    }
}