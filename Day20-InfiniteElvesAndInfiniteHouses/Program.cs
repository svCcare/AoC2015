using System.Diagnostics;

namespace Day20_InfiniteElvesAndInfiniteHouses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = 0;
            var houseIndex = 0;
            var presentThreshold = 34000000;

            do
            {
                result = 0;
                houseIndex++;
                var elfNumbers = CalculateFactors(houseIndex);
                var workingElves = elfNumbers.Where(x => x * 50 >= houseIndex);

                foreach (var elfNumber in workingElves)
                {
                    result += elfNumber * 11;
                }

            } while (result < presentThreshold);

            Console.WriteLine($"House index {houseIndex}");
        }

        public static List<int> CalculateFactors(int number)
        {
            var factors = new List<int>();
            int max = (int)Math.Sqrt(number);  // Round down

            for (int factor = 1; factor <= max; ++factor) // Test from 1 to the square root, or the int below it, inclusive.
            {
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor) // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                }
            }
            return factors;
        }
    }
}