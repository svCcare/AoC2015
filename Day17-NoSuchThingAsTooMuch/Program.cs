using SharedTools;

namespace Day17_NoSuchThingAsTooMuch
{
    internal class Program
    {
        public static List<List<int>> CreateCombinationsThatMatchesTarget(List<int> allValues, int target)
        {
            var collection = new List<List<int>>();
            for (int counter = 0; counter < (1 << allValues.Count); counter++)
            {
                List<int> combination = new List<int>();
                for (int i = 0; i < allValues.Count; i++)
                {
                    if ((counter & (1 << i)) == 0)
                        combination.Add(allValues[i]);
                }

                if (combination.Sum() == target)
                {
                    collection.Add(combination);
                }

            }
            return collection;
        }

        static void Main(string[] args)
        {
            int target = 150;

            var containers = new FileReader("input.txt", ReadOption.Lines).TextLines.Select(x => Convert.ToInt32(x)).ToList();
            var possibleCombinations = CreateCombinationsThatMatchesTarget(containers, target);

            // 2nd approach to generating all combinations

            List<int[]> output_numbers = new List<int[]>();

            // Calculate the number of combinations
            int combinations = (int)(Math.Pow(2, containers.Count) - 1);

            // Loop all combinations
            for (int i = 0; i < combinations; i++)
            {
                // Create subset lists
                List<int> subset = new List<int>();

                // Loop all numbers
                for (int j = 0; j < containers.Count; j++)
                {
                    if (((i & (1 << j)) >> j) == 1)
                    {
                        // Add the number and the index
                        subset.Add(containers[j]);
                    }
                }

                // Check if the target sum has been reached
                if (subset.Sum() == target)
                {
                    output_numbers.Add(subset.ToArray());
                    //break;
                }
            }

            Console.WriteLine(output_numbers.Count);
        }
    }
}