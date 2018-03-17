using System.Collections.Generic;
using Util;

namespace Procedural.Model {
    
    public static class RegionEnumerations {
        public static IEnumerable<Region> ResetValues(this IEnumerable<Region> regions, CellValue value) {
            foreach (var region in regions)
                region.ResetValues(value);
            return regions;
        }
    }
}
