using System.Collections.Generic;

namespace Util.Procedural
{
    public interface IMesh
    {
        UnityEngine.Mesh asUnityMesh();

        IList<Triangle> Triangles { get; }
    }
}