using UnityEngine;

namespace Util.Procedural
{
    public class Vertex
    {
        public override string ToString()
        {
            return string.Format("Index: {0}, Position: {1}", Index, Position);
        }

        public Vector3 Position
        {
            get { return position;  }
        }

        public int Index
        {
            get { return index; }
        }

        private readonly Vector3 position;
        
        private readonly int index;
        
        public Vertex(Vector3 position, int index)
        {
            this.position = position;
            this.index = index;
        }
    }
}