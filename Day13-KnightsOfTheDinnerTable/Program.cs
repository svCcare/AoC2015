using SharedTools;
using System.Data;

namespace Day13_KnightsOfTheDinnerTable
{
    internal class Program
    {
        private static readonly Dictionary<string, int> People = new()
        {
            { "Alice", 0 },
            { "Bob", 1 },
            { "Carol", 2 },
            { "David", 3 },
            { "Eric", 4 },
            { "Frank", 5 },
            { "George", 6 },
            { "Mallory", 7 },
        };

        private static readonly int[][] Scores = Enumerable.Range(0, 9).Select(e => new int[9]).ToArray();

        private static void Main()
        {
            var lines = new FileReader("input.txt", ReadOption.Lines).TextLines;
            var decodedLines = InputDecoder.Decode(lines);
            foreach (var data in decodedLines)
            {
                FillScoreMatrix(data);
            }

            var permutations = GetPermutations(Enumerable.Range(0, 9).ToArray(), 9);
            var overallScores = permutations.Select(permutation => GetScoreByPermutation(permutation)).ToArray();

            Console.WriteLine($"Part 1: {overallScores.Max()}");
            //Console.WriteLine($"Part 2: {distances.Max()}");
        }

        private static void FillScoreMatrix((string from, string to, int score) data)
        {
            var x = People[data.from];
            var y = People[data.to];
            var value = data.score;
            Scores[x][y] = value;
        }

        private static IEnumerable<int[]> GetPermutations(int[] list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new[] { t });
            }
            else
            {
                var perm = GetPermutations(list, length - 1);
                var result = perm.SelectMany(t => list.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new[] { t2 }).ToArray());
                return result;
            }
        }

        private static int GetScoreByPermutation(int[] permutation)
        {
            var happiness = 0;
            for (var i = 0; i < 8; i++)
            {
                happiness += Scores
                    [permutation[i]]
                    [permutation[i + 1]];
                happiness += Scores
                    [permutation[i + 1]]
                    [permutation[i]];
            }

            happiness += Scores
                [permutation[8]]
                [permutation[0]];
            happiness += Scores
                [permutation[0]]
                [permutation[8]];

            return happiness;
        }
    }
}