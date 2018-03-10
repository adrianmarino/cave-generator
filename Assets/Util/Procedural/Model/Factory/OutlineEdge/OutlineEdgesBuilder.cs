using System.Collections.Generic;

namespace Util.Procedural
{
    public static class OutlineEdgesBuilder
    {
        public static IList<Edge> build(IMesh mesh)
        {
            return new FullScanStrategy().build(mesh);
        }
    }
}