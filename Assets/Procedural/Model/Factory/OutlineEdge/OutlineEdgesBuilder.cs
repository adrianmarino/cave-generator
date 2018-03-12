using System.Collections.Generic;

namespace Procedural.Model
{
    public static class OutlineEdgesBuilder
    {
        public static IEnumerable<Edge> build(IMesh mesh)
        {
            // return new FullScanStrategy().build(mesh);
            return new FollowOutlinesStrategy().build(mesh);
        }
    }
}