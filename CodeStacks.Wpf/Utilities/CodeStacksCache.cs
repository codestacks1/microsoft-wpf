using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Caching;
using System.Security.AccessControl;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    /// <summary>
    /// 使用缓存机制
    /// </summary>
    public class CodeStacksCache
    {
        private CodeStacksCache() { }

        public static void SetCache(string cacheKey)
        {
            ObjectCache cache = MemoryCache.Default;
            string fileContents = cache[cacheKey] as string;

            if (fileContents == null)
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"CodeStacksCache\codestacks-global.md");
                CacheItemPolicy policy = new CacheItemPolicy();
                List<string> filePaths = new List<string>();
                filePaths.Add(path);

                try
                {
                    if (!File.Exists(path))
                    {
                        DirectoryInfo directoryInfo = Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "CodeStacksCache"));

                        using (File.Create(path, 2048)) { }
                    }


                    policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));
                    fileContents = File.ReadAllText(path);

                    cache.Set(cacheKey, fileContents, policy);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }

                object s = cache.Get(cacheKey);
            }
        }
    }
}
