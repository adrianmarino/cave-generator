using UnityEngine;
using Util;

namespace Procedural.Model {
    public static class GizmosUtil {

        public static void DrawPassage(Vector3 origin, RegionPassage passage) {
            Gizmos.color = Color.white;
            for (var i = 0; i < 20; i++)
                Gizmos.DrawLine(passage.CellACoords(origin), passage.CellBCoords(origin));
        }

        public static void DrawCell(Vector3 origin, Cell cell) {
            Gizmos.color = cell.isWall() ? Color.black : Color.white;
            Gizmos.DrawCube(cell.ToWorld(origin), Vector3.one);
        }

        public static void DrawSquare(Square square) {
            square.Edges.ForEach(node => DrawSquareEadgeNode(node, .4f));
            square.Centers.ForEach(node => DrawSquareNode(node, .1f));
        }

        public static void DrawSquareEadgeNode(SquareEdgeNode node, float size) {
            Gizmos.color = node.Active ? Color.black : Color.white;
            Gizmos.DrawCube(node.Position, Vector3.one * size);
        }

        private static void DrawSquareNode(SquareNode node, float size) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(node.Position, Vector3.one * size);
        }
    }
}
