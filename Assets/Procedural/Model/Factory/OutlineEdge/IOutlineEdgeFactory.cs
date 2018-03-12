using System.Collections.Generic;
using System.Linq;

namespace Procedural.Model
{
    public interface IOutlineEdgeFactory
    {
        IEnumerable<Edge> build(IMesh mesh);
    }
}