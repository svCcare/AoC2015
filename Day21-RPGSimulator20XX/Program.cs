using SharedTools;

namespace Day21_RPGSimulator20XX
{
    internal class Program
    {
        // do not need to be list (might be an array)
        public static List<(int, int, int)> Weapons = new()
        { (4,0,8), (5,0,10), (6,0,25), (7,0,40), (8,0,74) };

        public static List<(int, int, int)> Armors = new()
        { (0,0,0), (0,1,13), (0,2,31), (0,3,53), (0,4,75), (0,5,102) };

        public static List<(int, int, int)> Rings = new()
        { (0,0,0), (0,0,0), (1,0,25), (2,0,50), (3,0,100), (0,1,20), (0,2,40), (0,3,80) };

        static void Main(string[] args)
        {
            int[] attributes = new int[3]; // hp // dmg // armor
            var lines = new FileReader("input.txt", ReadOption.Lines).TextLines;
            for (int i = 0; i < lines.Length; i++)
            {
                attributes[i] = Convert.ToInt32(lines[i].Split(" ")[1]);
            }

            SimulateBattle(attributes);
        }

        private static void SimulateBattle(int[] bossStats)
        {
            List<int> goldSpentToWin = new();
            List<int> goldSpentToLose = new();
            var boss = new Stats(bossStats[0], bossStats[1], bossStats[2]);

            // generate combinations (1-4 elements)
            // 1-1 weapon MUST HAVE
            // 0 armor
            // 0-2 rings
            // {a}, {a,0}, {a,0,!}, {a,0,!,@} // possible combinations
            // each combination has its price
            // i already know that 1n element collections dont solve the issue
            var combinations = CreateCombinations();

            foreach (var combination in combinations)
            {
                boss.HitPoints = 104; // reset boss health
                var player = new Stats(100, combination.Item1, combination.Item2);
                var goldSpent = combination.Item3;

                do
                {
                    boss.HitPoints -= player.Damage - boss.Armor;
                    if (boss.HitPoints <= 0)
                    {
                        goldSpentToWin.Add(goldSpent);
                        break;
                        // return, win condition
                    }
                    player.HitPoints -= boss.Damage - player.Armor;
                    if (player.HitPoints <= 0)
                    {
                        goldSpentToLose.Add(goldSpent);
                        break;
                        // return, lose condition
                    }
                } while (player.HitPoints > 0 || boss.HitPoints > 0); // someone died
            }

            var ordered = goldSpentToWin.OrderBy(x => x);
            var orderedLoosing = goldSpentToLose.OrderByDescending(x => x);
        }

        public static List<(int, int, int)> CreateCombinations()
        {
            List<(int, int, int)> combinations = new();

            foreach (var weapon in Weapons)
            {
                foreach (var armor in Armors)
                {
                    foreach (var ring in Rings)
                    {
                        foreach (var secondRing in Rings)
                        {
                            if (secondRing == ring)
                            {
                                continue;
                            }
                            var dmgSum = weapon.Item1 + ring.Item1 + secondRing.Item1;
                            var armorSum = armor.Item2 + ring.Item2 + secondRing.Item2;
                            var price = weapon.Item3 + armor.Item3 + ring.Item3 + secondRing.Item3;

                            combinations.Add((dmgSum, armorSum, price));
                        }
                    }
                }
            }

            return combinations;
        }

    }
}