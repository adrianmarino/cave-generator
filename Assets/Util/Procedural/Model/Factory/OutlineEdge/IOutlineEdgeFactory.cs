using System.Collections.Generic;
using System.Linq;

namespace Util.Procedural
{
    public interface IOutlineEdgeFactory
    {
        IList<Edge> build(IMesh mesh);
    }
}