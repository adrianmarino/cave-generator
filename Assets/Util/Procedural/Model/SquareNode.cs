using UnityEngine;

namespace Util.Procedural
{
    public class SquareNode
    {
        public Vector3 Position { get; private set; }

        public SquareNode(Vector3 position)
        {
            Position = position;
        }
    }
}