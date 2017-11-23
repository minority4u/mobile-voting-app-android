using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;

namespace MSO.Common
{
    /// <summary>
    ///     The class helps with caching objects.
    ///     The cache is a SQLite Database that can be used on any platform.
    /// </summary>
    public static class CacheHelper
    {
        /// <summary>
        ///     Saves an object to the cache. If the object should be removed from the cache at a specific point, the absoluteExpiration parameter
        ///     should be specified or a expiration rule should be used.
        /// </summary>
        /// <param name="key">
        ///     The key for the cache entry
        /// </param>
        /// <param name="value">
        ///     The value for the cache entry
        /// </param>
        /// <param name="absoluteExpiration">
        ///     The absolute expiration time. That means, after this point, the cache entry is no longer valid and therefore will be removed from the cache.
        /// </param>
        /// <returns></returns>
        public static async Task SaveTocache(string key, object value,
            DateTime? absoluteExpiration = null)
        {
            await BlobCache.LocalMachine.InsertObject(key, value, absoluteExpiration);
        }

        /// <summary>
        ///     Tries to get a value from the cache.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the cache entry value to be found
        /// </typeparam>
        /// <param name="key"></param>
        /// <returns>
        ///     The cache entry, if found. Null otherwise.
        /// </returns>
        public static async Task<T> GetFromCache<T>(string key) where T : class
        {
            try
            {
                var obj = await BlobCache.LocalMachine.GetObject<T>(key);
                return obj;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        /// <summary>
        ///     Removes a cache entry from the cache.
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveFromCache(string key)
        {
            BlobCache.LocalMachine.Invalidate(key);
        }

        /// <summary>
        ///     Finds out whether a cache entry with a given key is existent in the cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<bool> IsIncache<T>(string key) where T : class
        {
            var result = (await GetFromCache<T>(key)) != null;
            return result;
        }
    }
}
