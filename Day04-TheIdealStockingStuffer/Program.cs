namespace Day04_TheIdealStockingStuffer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MD5Solver md5solver = new("ckczppom");

            var part1 = md5solver.Solve();
            var part2 = md5solver.Solve(true);

            Console.WriteLine($"Part 1: {part1.iterations}, found in: {part1.elapsed}ms");
            Console.WriteLine($"Part 2: {part2.iterations}, found in: {part2.elapsed}ms");
        }

    }
}