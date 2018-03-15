using System.Collections.Generic;
using System.Linq;

namespace Util
{
    public static class StringUtil
    {
        public static string ToString<T>(IList<T> list)
        {
            return string.Format("[{0}]", string.Join(", ", list.Select(it => it.ToString()).ToArray()));
        } 
    }
}