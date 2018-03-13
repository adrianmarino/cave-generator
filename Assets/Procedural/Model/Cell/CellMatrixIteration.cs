using System.Collections.Generic;

namespace Procedural.Model
{
    public static class CellMatrixIteration
    {
        public static IEnumerable<Cell> RadialForEach(
            this CellMatrix cellMatrix,
            Cell center,
            int radio
        )
        {
            return RadialForEach(cellMatrix, center.Coord, radio);
        }

        public static IEnumerable<Cell> RadialForEach(
            this CellMatrix cellMatrix, 
            Coord center, 
            int radio)
        {
            for (var x = center.X - radio; x <= center.X + radio; x++)
            {
                for (var y = center.Y - radio; y <= center.Y + radio; y++)
                {
                    yield return cellMatrix[x, y];
                }
            }
        }
    }
}