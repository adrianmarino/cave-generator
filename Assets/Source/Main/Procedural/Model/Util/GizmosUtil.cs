using UnityEngine;
using Util;

namespace Procedural.Model {
    public static class GizmosUtil {
        public static void DrawPassage(Vector3 origin, RegionPassage passage) {
            var color = Color.yellow;
            var cellACoords = passage.CellA.GetVector3(origin);
            if(passage.Distance > 0)
                Util.GizmosUtil.DrawLine(cellACoords, passage.CellB.GetVector3(origin), color);
            else
                Util.GizmosUtil.DrawCube(cellACoords, color, .5f);
        }

        public static void DrawCell(Vector3 origin, Cell cell) {
            Gizmos.color = cell.isWall() ? Color.black : Color.white;
            Gizmos.DrawCube(cell.GetVector3(origin), Vector3.one);
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
