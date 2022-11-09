using SharedTools;
using System.Diagnostics;

namespace Day08_Matchsticks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader("input.txt", ReadOption.Lines);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            CharactersCalculator charactersCalculator = new CharactersCalculator();

            foreach (var line in fileReader.TextLines)
            {
                charactersCalculator.Calculate(line);
            }

            //var result = charactersCalculator.Characters.Select(x => x.physicalCount - x.logicalCount).Sum();
            var result2 = charactersCalculator.Characters.Select(x => x.encodedPhysical - x.physicalCount).Sum();

            //Console.WriteLine($"Part 1: {result} | elapsed time: {timer.ElapsedMilliseconds}ms"); // ~10ms
            Console.WriteLine($"Part 2: {result2} | elapsed time: {timer.ElapsedMilliseconds}ms"); // ~30ms
        }
    }
}