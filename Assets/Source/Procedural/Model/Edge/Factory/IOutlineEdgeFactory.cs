using System.Collections.Generic;

namespace Procedural.Model
{
    public interface IOutlineEdgeFactory
    {
        IEnumerable<Edge> Build(IMesh mesh);
    }
}