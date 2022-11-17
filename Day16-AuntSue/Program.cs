using SharedTools;

namespace Day16_AuntSue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = new FileReader("input.txt", ReadOption.Lines).TextLines;
            int result = -1;
            int[] matches = new int[500];
            List<string> clues = new()
            {
                "children: 3", "cats: 7", "samoyeds: 2", "pomeranians: 3", "akitas: 0",
                "vizslas: 0", "goldfish: 5", "trees: 3", "cars: 2", "perfumes: 1",
            };

            foreach (var (line, index) in lines.WithIndex())
            {
                foreach (var clue in clues)
                {
                    if (line.Contains(clue))
                    {
                        matches[index]++;
                    }
                }

                if (matches[index] == 3)
                {
                    result = index + 1;
                    break;
                }
            }

            Console.WriteLine($"Part 1: {result}");
        }
    }
}