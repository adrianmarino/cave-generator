using System;
using System.Collections.Generic;
using System.Linq;

namespace Util {
    public static class Extensions {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var element in source)
                action(element);
        }

        public static IEnumerable<TSource> WhereNot<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate
        ) {
            return source.Where(it => !predicate(it));
        }

        public static IEnumerable<TSource> WhereNotNull<TSource>(this IEnumerable<TSource> source
        ) {
            return source.WhereNot(it => it == null);
        }
    }
}