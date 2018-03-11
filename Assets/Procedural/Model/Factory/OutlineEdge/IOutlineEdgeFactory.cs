using System.Collections.Generic;
using System.Linq;

namespace Procedural.Model
{
    public interface IOutlineEdgeFactory
    {
        IList<Edge> build(IMesh mesh);
    }
}