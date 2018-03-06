using UnityEngine;

namespace Util.Procedural
{
    public class SquareEdgeNodeMatrix
    {        
        public SquareEdgeNode this[int x, int y]
        {
            get { return nodes[x, y]; }
        }

        private void AddNode(float squareSideSize, Cell cell, Vector3 position)
        {
            nodes[cell.Point.X, cell.Point.Y] = new SquareEdgeNode(
                position,
                squareSideSize,
                cell.Value == 1
            );
        }

        private static Vector3 CreatePosition(CellMatrix cellMatrix, Cell cell)
        {
            return new Vector3(
                cellMatrix.BottomLeft.x + cell.Point.X,
                0,
                cellMatrix.BottomLeft.y + cell.Point.Y
            );
        }

        public long Width
        {
            get { return nodes.GetLength(0); }
        }
        
        public long Height
        {
            get { return nodes.GetLength(1); }
        }

        readonly SquareEdgeNode[,] nodes;

        public SquareEdgeNodeMatrix(CellMatrix cellMatrix, float squareSideSize)
        {
            nodes = new SquareEdgeNode[cellMatrix.Width, cellMatrix.Height];
            cellMatrix.ForEach(cell => AddNode(squareSideSize, cell, CreatePosition(cellMatrix, cell)));
        }
    }
}