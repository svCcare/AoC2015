using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedTools;
using System.Diagnostics;

namespace Day12_JSAbacusFramework.io
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new();
            var deserializedObject = JsonConvert.DeserializeObject<dynamic>(new FileReader("input.txt", ReadOption.All).Text);

            Console.WriteLine($"Part 1: {GetSum(deserializedObject)}");
            Console.WriteLine($"Part 2: {GetSum(deserializedObject, "red")}");
            Console.WriteLine($"Done in {stopwatch.ElapsedMilliseconds}ms");
        }

        static long GetSum(JObject o, string avoid = null)
        {
            bool shouldAvoid = o.Properties()
                .Select(a => a.Value).OfType<JValue>()
                .Select(v => v.Value).Contains(avoid);
            if (shouldAvoid) return 0;

            return o.Properties().Sum((dynamic a) => (long)GetSum(a.Value, avoid));
        }

        static long GetSum(JArray arr, string avoid)
        {
            return arr.Sum((dynamic a) => (long)GetSum(a, avoid));
        }

        static long GetSum(JValue val, string avoid)
        {
            return val.Type == JTokenType.Integer ? (long)val.Value : 0;
        }
    }
}