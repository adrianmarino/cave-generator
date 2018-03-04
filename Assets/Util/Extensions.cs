using System;
using System.Collections.Generic;

namespace Util
{
    public static class Enumerables
    {
        public static void ForEach<Cell>(this IEnumerable<Cell> @this, Action<Cell> action)
        {
            foreach (var cell in @this)
                action(cell);
        }
    }
}