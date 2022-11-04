using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Day02-IWasToldThereWouldBeNoMath.Tests")]
namespace Day02_IWasToldThereWouldBeNoMath
{
    internal static class InputDecoder
    {
        internal static int[] TranslateInput(string packageData)
        {
            return packageData
                .Split('x')
                .Select(x => Convert.ToInt32(x))
                .OrderBy(x => x)
                .ToArray();
        }
    }
}
