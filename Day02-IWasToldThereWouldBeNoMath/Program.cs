namespace Day02_IWasToldThereWouldBeNoMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new SharedTools.FileReader("input.txt", SharedTools.ReadOption.Lines);
            var packageFactory = new PackageFactory(fileReader.TextLines);

            Console.WriteLine($"Result One: {packageFactory.Packages.Sum(x => x.PaperNeeded)}");
            Console.WriteLine($"Result Two: {packageFactory.Packages.Sum(x => x.RibbonNeeded)}");
        }

    }
}