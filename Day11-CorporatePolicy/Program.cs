namespace Day11_CorporatePolicy
{
    internal class Program
    {
        private static readonly byte startingChar = 97;
        private static readonly byte lastChar = 122;
        private static readonly byte overflow = 123;
        private static readonly byte[] forbidden = new byte[3] { 105, 108, 111 };

        static void Main(string[] args)
        {
            var input = "vzbxkghb";
            var arr = new byte[8];

            for (byte i = 0; i < input.Length; i++)
            {
                arr[i] = (byte)input[i];
            }

            do
            {
                arr = Step(arr);
            } while (!Pass(arr));

            var part1result = new string(arr.Select(x => Convert.ToChar(x)).ToArray());

            Console.WriteLine($"Part 1: {part1result}");

            do
            {
                arr = Step(arr);
            } while (!Pass(arr));

            var part2result = new string(arr.Select(x => Convert.ToChar(x)).ToArray());
            Console.WriteLine($"Part 2: {part2result}");

        }

        private static byte[] Step(byte[] arr)
        {
            arr[7]++;
            DetectOverflow(arr);
            return arr;
        }

        private static byte[] DetectOverflow(byte[] arr)
        {
            if (arr.Max() != overflow)
            {
                return arr;
            }

            var overflowingIndex = Array.IndexOf(arr, overflow);
            arr[overflowingIndex] = startingChar;
            arr[overflowingIndex - 1]++;

            // for "zz" scenerio
            DetectOverflow(arr);

            return arr;
        }

        private static bool Pass(byte[] arr)
        {
            bool charsIncrementing = false;
            bool containsIllegalChar = true;
            byte pairCount = 0;

            // does not have i, o, l
            containsIllegalChar = arr.Any(x => forbidden.Contains(x));

            // 3 chars incrementing // hijklmmn // hij
            for (byte i = 0; i < arr.Length - 2; i++)
            {
                if (arr[i] + 1 == arr[i + 1] && arr[i] + 2 == arr[i + 2])
                {
                    charsIncrementing = true;
                }
            }

            // 2 pairs, no overlapping // abbceffg // bb ff
            for (byte i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    i++; // skipping a beat to cover the "bbb" case
                    pairCount++;
                }
            }

            return !containsIllegalChar && charsIncrementing && pairCount >= 2;
        }
    }
}