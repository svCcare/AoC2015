using SharedTools;
using System.Diagnostics;

namespace Day15_ScienceForHungryPeople
{
    internal class Program
    {
        private static void Main()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            var ingredients = new FileReader("input.txt", ReadOption.Lines).TextLines.Select(x => new Ingredient(x)).ToList();

            int[] possibleQuantities = new int[ingredients.Count];
            Dictionary<string, int> combinations = new Dictionary<string, int>();

            do
            {
                for (int i = 0; i < ingredients.Count; i++)
                {
                    possibleQuantities[i]++;
                    if (possibleQuantities[i] > 100)
                    {
                        possibleQuantities[i] = 0;
                    }
                    else
                    {
                        break;
                    }
                }

                if (possibleQuantities.Sum() != 100)
                {
                    continue;
                }

                // create combination
                var combinationKey = string.Join(";", possibleQuantities);

                if (combinations.ContainsKey(combinationKey))
                {
                    break;
                }

                int score = CalculateScore(ingredients, possibleQuantities);
                if (score < 0)
                {
                    combinationKey += "!";
                    score *= -1;
                }
                combinations.Add(combinationKey, score);

            } while (true);

            var bestScore = combinations.OrderByDescending(x => x.Value).First();

            Console.WriteLine($"Winning score {bestScore.Value} | elapsed: {timer.ElapsedMilliseconds}ms");
        }

        private static int CalculateScore(List<Ingredient> ingredientsF, int[] possibleQuantities)
        {
            int capacity = 0;
            int durability = 0;
            int flavor = 0;
            int texture = 0;
            int calories = 0;

            for (int i = 0; i < possibleQuantities.Length; i++)
            {
                capacity += ingredientsF[i].Capacity * possibleQuantities[i];
                durability += ingredientsF[i].Durability * possibleQuantities[i];
                flavor += ingredientsF[i].Flavor * possibleQuantities[i];
                texture += ingredientsF[i].Texture * possibleQuantities[i];
                calories += ingredientsF[i].Calories * possibleQuantities[i];
            }


            var score = calories != 500 ? 0 : Math.Max(0, capacity) * Math.Max(0, durability) * Math.Max(0, flavor) * Math.Max(0, texture);
            return score;
        }
    }
}