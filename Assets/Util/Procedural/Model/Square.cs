using System.Collections.Generic;

namespace Util.Procedural
{
    public class Square
    {
        public IList<SquareEdgeNode> Edges
        {
            get { return new List<SquareEdgeNode> {TopLeft, TopRight, BottomLeft, BottomRight}; }
        }

        public IList<SquareNode> Centers
        {
            get { return new List<SquareNode> {CentreTop, CentreBottom, CentreLeft, CentreRight}; }
        }

        public SquareNode CentreTop
        {
            get { return TopLeft.Right; }
        }

        public SquareNode CentreBottom
        {
            get { return BottomLeft.Right; }
        }

        public SquareNode CentreLeft
        {
            get { return BottomLeft.Above; }
        }

        public SquareNode CentreRight
        {
            get { return BottomRight.Above; }
        }
       
        public SquareEdgeNode BottomRight { get; private set; }

        public SquareEdgeNode BottomLeft { get; private set; }

        public SquareEdgeNode TopRight { get; private set; }

        public SquareEdgeNode TopLeft { get; private set; }

        public int Configuration { get; private set; }
        
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
 
            if (topLeft.Active) Configuration += 8;
            if (topRight.Active) Configuration += 4;
            if (bottomRight.Active) Configuration += 2;
            if (bottomLeft.Active) Configuration += 1;
        }
    }
}