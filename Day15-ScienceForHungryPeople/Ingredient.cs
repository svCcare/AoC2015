namespace Day15_ScienceForHungryPeople
{
    internal class Ingredient
    {
        public string Name { get; }
        public int Capacity { get; }
        public int Durability { get; }
        public int Flavor { get; }
        public int Texture { get; }
        public int Calories { get; }

        public Ingredient(string input)
        {
            var parts = input.Split(' ');
            Name = parts[0].Replace(":", string.Empty);
            Capacity = Convert.ToInt32(parts[2].Replace(",", string.Empty));
            Durability = Convert.ToInt32(parts[4].Replace(",", string.Empty));
            Flavor = Convert.ToInt32(parts[6].Replace(",", string.Empty));
            Texture = Convert.ToInt32(parts[8].Replace(",", string.Empty));
            Calories = Convert.ToInt32(parts[10].Replace(",", string.Empty));
        }
    }
}