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
        
        public override string ToString()
        {
            return string.Format("Index: {0}, Position: {1}", Index, Position);
        }

        #region Comparation

        protected bool Equals(Vertex other)
        {
            return position.Equals(other.position) && index == other.index;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Vertex) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (position.GetHashCode() * 397) ^ index;
            }
        }        

        #endregion

        #region Properties

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
        
        public Vertex(Vector3 position, int index)
        {
            this.position = position;
            this.index = index;
        }
    }
}