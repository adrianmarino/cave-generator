using UnityEngine;

namespace Util.Procedural
{
    public static class GizmosUtil
    {
        public static void DrawPoint(ProceduralMap map, Cell cell)
        {
            var position = new Vector3(
                -map.Width / 2 + cell.Point.X, 
                0,
                -map.Height / 2 + cell.Point.Y
            );

            Gizmos.color = cell.Value == 1 ? Color.black : Color.white;
            Gizmos.DrawCube(position, Vector3.one);
        }
    }
}