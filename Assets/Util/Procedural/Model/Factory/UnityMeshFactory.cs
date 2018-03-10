using System.Linq;

namespace Util.Procedural
{
    public static class UnityMeshFactory
    {
        public static UnityEngine.Mesh Create(IMesh mesh)
        {
            var triangleVertices = TriangleUtil.VerticesFrom(mesh.Triangles);

            var verticesOrderedByIndex = VertexUtil.sorByIndex(triangleVertices.Distinct());

            var unityMesh = new UnityEngine.Mesh
            {
                vertices = VertexUtil.PositionsFrom(verticesOrderedByIndex).ToArray(),
                triangles = VertexUtil.IndexFrom(triangleVertices).ToArray()
            };
            unityMesh.RecalculateNormals();
            return unityMesh;
        }
    }
}