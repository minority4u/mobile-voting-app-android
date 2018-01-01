using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSO.Common
{
    public static class ListExtensions
    {
        private static readonly Random Rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;

            while (n > 1)
            {
                n--;
                var k = Rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static async Task ReplaceAllItemsAsync<T>(this ICollection<T> collection,
            ICollection<T> collectionWithNewItems)
        {
            await Task.Run(() =>
            {
                collection.Clear();
                foreach (var element in collectionWithNewItems)
                    collection.Add(element);
            });
        }
    }
}
