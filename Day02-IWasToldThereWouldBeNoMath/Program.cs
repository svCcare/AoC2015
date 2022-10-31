using SharedTools;

namespace Day02_IWasToldThereWouldBeNoMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader("input.txt", ReadOption.Lines);
            var packageFactory = new PackageFactory(fileReader.TextLines);

            Console.WriteLine($"Part 1: {packageFactory.Packages.Sum(x => x.PaperNeeded)}");
            Console.WriteLine($"Part 2: {packageFactory.Packages.Sum(x => x.RibbonNeeded)}");
        }

    }
}