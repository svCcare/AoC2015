using SharedTools;

namespace Day14_ReindeerOlympics
{
    internal class Program
    {
        private static void Main()
        {
            var input = new FileReader("input.txt", ReadOption.Lines).TextLines;
            var result = Solve(input);
        }

        private static int Solve(string[] input)
        {
            var reindeers = input.Select(i => new Reindeer(i));

            Dictionary<string, int> deerScores = new();
            foreach (var deer in reindeers)
            {
                deerScores.Add(deer.Name, 0);
            }

            for (int i = 1; i < 2503; i++)
            {
                Dictionary<Reindeer, int> distances = new();
                foreach (var reindeer in reindeers)
                {
                    distances.Add(reindeer, reindeer.Fly(i));
                }

                var winningScore = distances.OrderByDescending(x => x.Value).First().Value;

                var winningNames = distances.Where(x => x.Value == winningScore).Select(x => x.Key.Name);
                foreach (var name in winningNames)
                {
                    deerScores[name]++;
                }
            }

            return deerScores.Max(x => x.Value);
        }

        private class Reindeer
        {
            private readonly int _duration;
            private readonly int _rest;
            private readonly int _speed;

            public string Name { get; set; }

            public Reindeer(string input)
            {
                var p = input.Split(' ');
                Name = p[0];
                _speed = int.Parse(p[3]);
                _duration = int.Parse(p[6]);
                _rest = int.Parse(p[13]);
            }

            public int Fly(int time)
            {
                return time / (_duration + _rest) * _speed * _duration + Math.Min(_duration, time % (_duration + _rest)) * _speed;
                // number iterations * travel distance // last partial iteration
            }
        }
    }
}