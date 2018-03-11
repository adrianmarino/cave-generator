using UnityEngine;

namespace Procedural.Model
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