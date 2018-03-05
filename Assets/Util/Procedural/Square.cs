using System.Collections.Generic;

namespace Util.Procedural
{
    public class Square
    {
        public List<SquareEdgeNode> Edges
        {
            get { return new List<SquareEdgeNode> {TopLeft, TopRight, BottomLeft, BottomRight}; }
        }

        public List<SquareNode> Centers
        {
            get { return new List<SquareNode> {CenterTop, CenterButtom, CenterLeft, CenterRight}; }
        }
        
        public SquareEdgeNode TopLeft { get; private set; }

        public SquareEdgeNode TopRight { get; private set; }

        public SquareEdgeNode BottomLeft { get; private set; }

        public SquareEdgeNode BottomRight { get; private set; }

        private SquareNode CenterTop
        {
            get { return TopLeft.Right; }
        }

        private SquareNode CenterButtom
        {
            get { return BottomLeft.Right; }
        }

        private SquareNode CenterLeft
        {
            get { return BottomLeft.Above; }
        }

        private SquareNode CenterRight
        {
            get { return BottomRight.Above; }
        }

        public Square(
            SquareEdgeNode topLeft, 
            SquareEdgeNode topRight, 
            SquareEdgeNode bottomLeft, 
            SquareEdgeNode bottomRight
        )
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }
    }
}