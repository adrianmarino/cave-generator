using UnityEngine;

namespace Util.Procedural
{
    public class SquareEdgeNode: SquareNode
    {
        public bool Active { get; private set; }
        public SquareNode Above { get; private set; }
        public SquareNode Right { get; private set; }

        public SquareEdgeNode(Vector3 squareEdgePosition, float squakeSideSize, bool active) : base(squareEdgePosition)
        {
            Above = new SquareNode(squareEdgePosition + Vector3.forward * (squakeSideSize / 2f));
            Right = new SquareNode(squareEdgePosition + Vector3.right * (squakeSideSize / 2f));
            Active = active;
        }
    }
}