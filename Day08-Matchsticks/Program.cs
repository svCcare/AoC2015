using SharedTools;

namespace Day08_Matchsticks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader("input.txt", ReadOption.Lines);

            CharactersCalculator charactersCalculator = new CharactersCalculator();

            foreach (var line in fileReader.TextLines)
            {
                charactersCalculator.Calculate(line);
            }

            var result = charactersCalculator.Characters.Select(x => x.physicalCount - x.logicalCount).Sum();

            Console.WriteLine($"Part 1: ");
        }
    }
}