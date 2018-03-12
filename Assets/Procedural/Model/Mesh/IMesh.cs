using System.Collections.Generic;

namespace Procedural.Model
{
    public interface IMesh
    {
        UnityEngine.Mesh asUnityMesh();

        IEnumerable<Triangle> Triangles { get; }

        IEnumerable<Vertex> ExternalVertices { get; }
    }
}