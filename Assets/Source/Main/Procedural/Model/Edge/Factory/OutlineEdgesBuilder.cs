using System.Collections.Generic;

namespace Procedural.Model {
    public static class OutlineEdgesBuilder {
        public static IEnumerable<Edge> build(IMesh mesh) {
            // return new FullScanStrategy().Build(mesh);
            return new FollowOutlinesStrategy().Build(mesh);
        }
    }
}