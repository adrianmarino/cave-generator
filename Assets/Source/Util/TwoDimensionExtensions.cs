using System.Collections.Generic;

namespace Util
{
    public static class TwoDimensionExtensions
    {
        public static IEnumerable<T> RadialForEach<T>(
            this ITwoDimensionIndexable<T> source, 
            int centerX,
            int centerY,
            int radio
        )
        {
            for (var x = centerX - radio; x <= centerX + radio; x++)
            {
                for (var y = centerY - radio; y <= centerY + radio; y++)
                {
                    yield return source[x, y];
                }
            }
        }
    }
}