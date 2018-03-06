using System.Collections.Generic;
using System.Linq;

namespace Util.Procedural
{
    public class SquareMesh
    {
        public override string ToString()
        {
            return string.Format("Triangles: {0}", StringUtil.ToString(Triangles));
        }

        public IList<Triangle> Triangles { get; set; }

        public IList<Vertex> Vertices { get; private set; }

        public SquareMesh() : this(new List<Triangle>())
        {
        }

        public SquareMesh(IList<Triangle> triangles)
        {
            Triangles = triangles;
            Vertices = triangles.SelectMany(it => it.Vertices).Distinct().ToList();
        }
    }
}