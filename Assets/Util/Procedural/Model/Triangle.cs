using System.Collections.Generic;
using System.Linq;

namespace Util.Procedural
{
    public class Triangle
    {
        public static IEnumerable<Vertex> VerticesFrom(IEnumerable<Triangle> triangles)
        {
            return triangles.SelectMany(it => it.Vertices).Distinct();
        }
        
        public static IEnumerable<int> IndexesFrom(IEnumerable<Triangle> triangles)
        {
            return triangles.SelectMany(it => it.Vertices).Select(it => it.Index);
        }

        public override string ToString()
        {
            return string.Format("Vertices: {0}", StringUtil.ToString(Vertices));
        }
        
        public bool Contains(Vertex vertex)
        {
            return Vertices.Contains(vertex);
        }

        public Vertex[] Vertices { get; private set; }

        public Triangle(Vertex vertex1, Vertex vertex2, Vertex vertex3)
        {
            Vertices = new[] {vertex1, vertex2, vertex3};
            Vertices.ForEach(it => it.belongTo(this));
        }
    }
}