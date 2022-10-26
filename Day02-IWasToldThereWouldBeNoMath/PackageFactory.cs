namespace Day02_IWasToldThereWouldBeNoMath
{
    internal class PackageFactory
    {
        internal List<Package> Packages { get; set; } = new List<Package>();

        internal PackageFactory(IEnumerable<string> packagesData)
        {
            foreach (var packageData in packagesData)
            {
                var dimensions = TranslateInput(packageData);
                Packages.Add(new Package(dimensions[0], dimensions[1], dimensions[2]));
            }
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
