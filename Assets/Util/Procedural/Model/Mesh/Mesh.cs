using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util.Procedural
{
    public class Mesh: IMesh
    {        
        public UnityEngine.Mesh asUnityMesh()
        {
            return UnityMeshFactory.Create(this);
        }

        #region Properties

        public IList<Triangle> Triangles { get; protected set; }

        #endregion
     
        #region Constructors

        public Mesh(IEnumerable<IMesh> meshes)
        {
            Triangles = meshes.SelectMany(mesh => mesh.Triangles).ToList();
        }
        
        public Mesh(params Triangle[] triangles)
        {
            Triangles = new List<Triangle>(triangles);
        }
        
        public Mesh(IList<Triangle> triangles)
        {
            Triangles = triangles;
        }

        public Mesh() : this(new List<Triangle>())
        {
        }

        #endregion
    }
}