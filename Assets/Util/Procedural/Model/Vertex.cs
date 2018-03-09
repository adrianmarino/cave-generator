using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util.Procedural
{
    public class Vertex
    {        
        public static IEnumerable<Vector3> PositionsFrom(IEnumerable<Vertex> vertices)
        {
            return vertices.Select(it => it.Position);
        }

        public bool makeUpOutlineEdge(Vertex another)
        {
            return SharedTriangles(another).ToArray().Length == 1;
        }
        
        public IEnumerable<Triangle> SharedTriangles(Vertex another)
        {
            return _triangles.Where(it => it.Contains(another));
        }
        
        internal void belongTo(Triangle triangle)
        {
            _triangles.Add(triangle);
        }
        
        public override string ToString()
        {
            return string.Format("Index: {0}, Position: {1}", Index, Position);
        }

        #region Comparation

        protected bool Equals(Vertex other)
        {
            return position.Equals(other.position) && index == other.index && Equals(_triangles, other._triangles);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vertex) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = position.GetHashCode();
                hashCode = (hashCode * 397) ^ index;
                hashCode = (hashCode * 397) ^ (_triangles != null ? _triangles.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

        #region Properties

        public HashSet<Triangle> Triangles
        {
            get { return _triangles; }
        }

        public Vector3 Position
        {
            get { return position;  }
        }

        public int Index
        {
            get { return index; }
        }

        #endregion

        private readonly Vector3 position;
        
        private readonly int index;
        
        private readonly HashSet<Triangle> _triangles;

        public Vertex(Vector3 position, int index)
        {
            _triangles = new HashSet<Triangle>();
            this.position = position;
            this.index = index;
        }
    }
}