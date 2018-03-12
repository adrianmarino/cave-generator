using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Procedural.Model
{
    public class Mesh: IMesh
    {
        public override string ToString()
        {
            return string.Format("Mesh: {0}", JsonUtility.ToJson(Triangles));
        }

        public UnityEngine.Mesh asUnityMesh()
        {
            return UnityMeshFactory.Create(this);
        }

        #region Properties

        public IList<Triangle> Triangles { get; protected set; }
        
        public IEnumerable<Vertex> ExternalVertices
        {
            get { return externalvertices ?? (externalvertices = Triangles.NonInner().DistinctVertices()); }
        }

        #endregion

        private IEnumerable<Vertex> externalvertices;

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