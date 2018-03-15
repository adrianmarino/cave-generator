using System.Linq;
using NUnit.Framework.Internal;
using Util;
using StringUtil = Util.StringUtil;

namespace Procedural.Model
{
    public class Triangle
    {
        public override string ToString()
        {
            return string.Format("{ Vertices: [{0}] }", StringUtil.ToString(Vertices));
        }

        public bool Contains(Vertex vertex)
        {
            return Vertices.Contains(vertex);
        }

        public Vertex[] Vertices { get; private set; }

        public bool Inner { get; private set; }


        public Triangle(Vertex vertex1, Vertex vertex2, Vertex vertex3) : this(vertex1, vertex2, vertex3, false)
        {
        }
       
        public Triangle(Vertex vertex1, Vertex vertex2, Vertex vertex3, bool inner)
        {
            Vertices = new[] {vertex1, vertex2, vertex3};
            Vertices.ForEach(it => it.belongTo(this));
            Inner = inner;
        }
    }
}