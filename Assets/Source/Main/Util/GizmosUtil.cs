using UnityEngine;

namespace Util {
    public static class GizmosUtil {
        public static void DrawLine(Vector3 vectorA, Vector3 vectorB, Color color, int intensity = 20) {
            Gizmos.color = color;
            for (var i = 0; i < intensity; i++) Gizmos.DrawLine(vectorA, vectorB);
        }

        public static void DrawCube(Vector3 center, Color color, float size) {
            Gizmos.color = color;
            Gizmos.DrawCube(center, Vector3Util.Dimention(size)); 
        }
    }
}
