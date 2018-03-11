using System.Linq;

namespace Util.Procedural
{
    public static class UnityMeshFactory
    {
        public static UnityEngine.Mesh Create(IMesh mesh)
        {
            var triangleVertices = mesh.Triangles.Vertices();
            var unityMesh = new UnityEngine.Mesh
            {
                vertices = triangleVertices.Distinct().sorByIndex().Positions().ToArray(),
                triangles = triangleVertices.Indexes().ToArray()
            };
            unityMesh.RecalculateNormals();
            return unityMesh;
        }
    }
}