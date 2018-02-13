using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MarketAnalysis.Utility
{
    /// <summary>
    /// Queryable extensions
    /// </summary>
    public static class IEnumerableHelper
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static IQueryable<TSource> DistinctBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
        {
            return source.GroupBy(p => keySelector).Select(p => p.FirstOrDefault());

            //var query = people.DistinctBy(p => p.Id);
            //var query = people.DistinctBy(p => new { p.Id, p.Name });
        }
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            return source.Where(element => seenKeys.Add(keySelector(element)));

            //var query = people.DistinctBy(p => p.Id);
            //var query = people.DistinctBy(p => new { p.Id, p.Name });
        }

        private static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static T ThrowIf<T>(this T val, Func<T, bool> predicate, Exception ex)
        {
            if (predicate(val))
                throw ex;
            return val;
        }

        public static IEnumerable<T> ThrowIfAny<T>(this IEnumerable<T> values, Func<T, bool> predicate, Exception ex)
        {
            if (values.Any(predicate))
                throw ex;
            return values;
        }

        /// <summary>
        /// var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        /// old way using or's
        /// var old = numbers.Where(x => x == 2 || x == 3 || x == 5 || x == 7);
        /// new way using In
        /// var primes = numbers.Where(x => x.In(2, 3, 5, 7));
        /// </summary>
        public static bool In<T>(this T source, params T[] list)
        {
            return list.ToList().Contains(source);
        }

        public static T MinOrDefault<T>(this IEnumerable<T> source, T defaultValue)
        {
            if (source.Any<T>())
                return source.Min<T>();

            return defaultValue;
        }

        public static T MaxOrDefault<T>(this IEnumerable<T> source, T defaultValue)
        {
            if (source.Any<T>())
                return source.Max<T>();

            return defaultValue;
        }
    }
}