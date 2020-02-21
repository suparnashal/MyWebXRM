using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Logging
{
    public static class TestContextData
    {
        public static ConcurrentDictionary<String, List<String>> contextData = new ConcurrentDictionary<string, List<string>>();

        public static void Add(string locator, string data)
        {
            if (!contextData.ContainsKey(locator))
            {
                contextData.TryAdd(locator, new List<string> { data });
            }
            else
            {
                contextData[locator].Add(data);
            }

        }

        public static string GetFinalMessage(string locator)
        {
            if (!contextData.ContainsKey(locator))
            {
                return "";
            }
            else
            {
               return string.Join("\n", contextData[locator].ToArray());
            }
        }
    }
}
