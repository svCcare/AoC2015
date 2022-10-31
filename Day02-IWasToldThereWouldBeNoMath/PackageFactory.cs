using System.Diagnostics;

namespace Day02_IWasToldThereWouldBeNoMath
{
    internal class PackageFactory
    {
        internal List<Package> Packages { get; set; } = new List<Package>();

        internal PackageFactory(string[] packagesData)
        {
            var timer = new Stopwatch();
            timer.Start();

            foreach (var packageData in packagesData)
            {
                var dimensions = TranslateInput(packageData);
                Packages.Add(new Package(dimensions[0], dimensions[1], dimensions[2]));
            }

            //B: Run stuff you want timed
            timer.Stop();
        }

        private int[] TranslateInput(string packageData)
        {
            return packageData
                .Split('x')
                .Select(x => Convert.ToInt32(x))
                .OrderBy(x => x)
                .ToArray();
        }
    }
}
