using UnityEngine;
using Util;

namespace Procedural.Model
{
    public static class GizmosUtil
    {
        public static void DrawCell(CellMatrix cellMatrix, Cell cell)
        {
            var position = new Vector3(
                cellMatrix.BottomLeft.x + cell.Coord.X, 
                0,
                cellMatrix.BottomLeft.y + cell.Coord.Y
            );
            Gizmos.color = cell.isWall() ? Color.black : Color.white;
            Gizmos.DrawCube(position, Vector3.one);
        }

        public static void DrawSquare(Square square)
        {
            square.Edges.ForEach(node => DrawSquareEadgeNode(node, .4f));
            square.Centers.ForEach(node => DrawSquareNode(node, .1f));
        }

        public static void DrawSquareEadgeNode(SquareEdgeNode node, float size)
        {
            Gizmos.color = node.Active ? Color.black : Color.white;
            Gizmos.DrawCube(node.Position, Vector3.one * size);
        }

        private static void DrawSquareNode(SquareNode node, float size)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(node.Position, Vector3.one * size);
        }
    }
}