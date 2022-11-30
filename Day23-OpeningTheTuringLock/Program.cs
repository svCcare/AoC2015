using SharedTools;

namespace Day23_OpeningTheTuringLock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = new FileReader("input.txt", ReadOption.Lines).TextLines;
            var factory = new ActionFactory();
            var actions = lines.Select(x => factory.Build(x));

        }
    }
}