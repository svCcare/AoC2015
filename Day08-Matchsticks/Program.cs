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

            CharactersCalculator charactersCalculator = new();

            foreach (var line in fileReader.TextLines)
            {
                charactersCalculator.Calculate(line);
            }

            var timeElapsed = timer.ElapsedMilliseconds;
            Console.WriteLine($"Part 1: {charactersCalculator.Characters["result1"]}"); // ~10ms
            Console.WriteLine($"Part 2: {charactersCalculator.Characters["result2"]}"); // ~30ms
            Console.WriteLine($"Overall time elapsed: {timeElapsed}ms"); // ~20ms
        }
    }
}