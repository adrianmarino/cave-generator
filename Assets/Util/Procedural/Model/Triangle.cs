namespace Util.Procedural
{
    public class Triangle
    {
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