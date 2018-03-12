using System.Collections.Generic;

namespace Procedural.Model
{
    public interface IMesh
    {
        UnityEngine.Mesh asUnityMesh();

        IList<Triangle> Triangles { get; }

        IEnumerable<Vertex> ExternalVertices { get; }
    }
}