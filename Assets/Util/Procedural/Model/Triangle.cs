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
        
        public bool Contains(Vertex vertex)
        {
            return Vertices.Any(it => it.Equals(vertex));
        }
        
        public override string ToString()
        {
            return string.Format("Vertices: {0}", StringUtil.ToString(Vertices));
        }

        public Vertex[] Vertices { get; private set; }

        public Triangle(params Vertex[] vertices)
        {
            Vertices = vertices;
        }
    }
}