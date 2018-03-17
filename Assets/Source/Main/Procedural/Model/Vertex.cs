using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Procedural.Model {
    public class Vertex {
        protected bool Equals(Vertex other) {
            return position.Equals(other.position);
        }

        public IEnumerable<Vertex> ExternalVertices {
            get { return externalvertices ?? (externalvertices = Triangles.NonInner().DistinctVertices()); }
        }

        public bool makeUpOutlineEdge(Vertex another) {
            return SharedTriangles(another).ToArray().Length == 1;
        }

        public IEnumerable<Triangle> SharedTriangles(Vertex another) {
            return triangles.Where(it => it.Contains(another));
        }

        internal void belongTo(Triangle triangle) {
            triangles.Add(triangle);
        }

        public override string ToString() {
            return string.Format("Index: {0}, Position: {1}", Index, Position);
        }

        #region Properties

        public IEnumerable<Triangle> Triangles {
            get { return triangles; }
        }

        public Vector3 Position {
            get { return position; }
        }

        public int Index {
            get { return index; }
        }

        #endregion

        private IEnumerable<Vertex> externalvertices;

        private readonly Vector3 position;

        private readonly int index;

        private readonly HashSet<Triangle> triangles;

        public Vertex(Vector3 position, int index) {
            triangles = new HashSet<Triangle>();
            this.position = position;
            this.index = index;
        }
    }
}