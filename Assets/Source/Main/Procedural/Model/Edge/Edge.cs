using Procedural.Model;

namespace Procedural {
    public class Edge {
        protected bool Equals(Edge other) {
            return VertexA.Equals(other.VertexA) && VertexB.Equals(VertexB);
        }

        public Vertex VertexA { get; private set; }

        public Vertex VertexB { get; set; }

        public Edge(Vertex vertexA) {
            VertexA = vertexA;
        }

        public Edge(Vertex vertexA, Vertex vertexB) {
            VertexA = vertexA;
            VertexB = vertexB;
        }
    }
}