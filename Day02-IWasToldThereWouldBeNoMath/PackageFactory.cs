
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Day02-IWasToldThereWouldBeNoMath.Tests")]
namespace Day02_IWasToldThereWouldBeNoMath
{
    internal class PackageFactory
    {
        internal List<Package> Packages { get; set; } = new List<Package>();

        internal PackageFactory(string[] packagesData)
        {
            foreach (var packageData in packagesData)
            {
                var dimensions = InputDecoder.TranslateInput(packageData);
                Packages.Add(new Package(dimensions[0], dimensions[1], dimensions[2]));
            }
        }
    }
}
