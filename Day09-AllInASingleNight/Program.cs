using SharedTools;

namespace Day09_AllInASingleNight
{
    internal class Program
    {
        private static readonly Dictionary<string, int> Places = new()
        {
            { "Tristram", 1 },
            { "AlphaCentauri", 2 },
            { "Snowdin", 3 },
            { "Tambi", 4 },
            { "Faerun", 5 },
            { "Straylight", 6 },
            { "Arbre", 7 },
            { "Norrath", 0 }
        };

        private static readonly int[][] Distances = Enumerable.Range(0, 8).Select(e => new int[8]).ToArray();

        private static void Main()
        {
            var lines = new FileReader("input.txt", ReadOption.Lines).TextLines;
            var decodedLines = InputDecoder.Decode(lines);

            foreach (var words in decodedLines)
            {
                FillDistanceMatrix(words);
            }

            var permutations = GetPermutations(Enumerable.Range(0, 2).ToArray(), 2);
            var distances = permutations.Select(permutation => GetDistanceTravelled(permutation)).ToArray();

            Console.WriteLine($"Part 1: {distances.Min()}");
            Console.WriteLine($"Part 2: {distances.Max()}");
        }

        private static void FillDistanceMatrix((string from, string to, string distance) words)
        {
            var x = Places[words.from];
            var y = Places[words.to];
            var value = Convert.ToInt32(words.distance);
            Distances[x][y] = value;
            Distances[y][x] = value;
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

        private static int GetDistanceTravelled(int[] permutation)
        {
            var distance = 0;
            for (var i = 0; i < 7; i++)
            {
                distance += Distances[permutation[i]][permutation[i + 1]];
            }
            return distance;
        }
    }
}