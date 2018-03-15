using System.Collections.Generic;
using Util;

namespace Procedural.Model
{
    public static class CellMatrixEnumetions
    {
        public static IEnumerable<Cell> RadialForEach(
            this ITwoDimensionIndexable<Cell> matrix,
            Cell center,
            int radio
        )
        {
            return matrix.RadialForEach(center.Coord.X, center.Coord.Y, radio);
        }
    }
}