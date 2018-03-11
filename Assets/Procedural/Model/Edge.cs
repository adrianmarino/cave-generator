using Procedural.Model;

namespace Procedural
{
    public class Edge
    {
        protected bool Equals(Edge other)
        {
            return Equals(Vertex1, other.Vertex1) && Equals(Vertex2, other.Vertex2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Edge) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Vertex1 != null ? Vertex1.GetHashCode() : 0) * 397) ^ (Vertex2 != null ? Vertex2.GetHashCode() : 0);
            }
        }

        public Vertex Vertex1 { get; private set; }

        public Vertex Vertex2 { get; private set; }

        public Edge(Vertex vertex1, Vertex vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }
    }
}