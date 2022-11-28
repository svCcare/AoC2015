namespace Day21_RPGSimulator20XX
{
    internal class Stats
    {
        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }

        public Stats(int hitPoints, int damage, int armor)
        {
            HitPoints = hitPoints;
            Damage = damage;
            Armor = armor;  
        }
    }
}
