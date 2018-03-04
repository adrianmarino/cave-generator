using UnityEngine;

namespace Util
{
    public class GizmosUtil
    {
        public static void DrawPoint(Map map, Cell cell)
        {
            Gizmos.color = cell.Value == 1 ? Color.black : Color.white;
            Vector3 position = new Vector3(
                -map.Width / 2 + cell.Point.X + .5f, 
                0, 
                -map.Height / 2 + cell.Point.Y + .5f
            );
            Gizmos.DrawCube(position, Vector3.one);
        }
    }
}