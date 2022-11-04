using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Day02-IWasToldThereWouldBeNoMath.Tests")]
namespace Day02_IWasToldThereWouldBeNoMath
{
    internal class Package
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;

        internal int PaperNeeded { get; private set; }
        internal int RibbonNeeded { get; private set; }

        private Package() { }

        internal Package(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            PaperNeeded = CalculateArea() + CalculateOffset();
            RibbonNeeded = CalculateRibbon();
        }

        private int CalculateArea() => (2 * a * b) + (2 * b * c) + (2 * c * a);

        private int CalculateOffset() => a * b;

        private int CalculateRibbon() => a + a + b + b + (a * b * c);
    }
}
