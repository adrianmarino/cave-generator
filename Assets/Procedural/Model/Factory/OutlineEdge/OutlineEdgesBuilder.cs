using System.Collections.Generic;

namespace Procedural.Model
{
    public static class OutlineEdgesBuilder
    {
        public static IList<Edge> build(IMesh mesh)
        {
            return new FullScanStrategy().build(mesh);
        }
    }
}