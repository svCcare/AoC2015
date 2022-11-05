using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Day06-ProbablyAFireHazard.Tests")]
namespace Day06_ProbablyAFireHazard
{
    internal class HouseDecoration
    {
        // for part 1
        //private bool[,] _lamps = new bool[1000, 1000];

        // for part 2
        private int[,] _lamps = new int[1000, 1000];

        internal int CountLightedUp() => _lamps.Cast<bool>().ToList().Where(x => x == true).Count();
        internal int CalculateBrightness() => _lamps.Cast<int>().ToList().Sum(x => x);

        internal void ExecuteInstructions(IEnumerable<Instruction> operations)
        {
            foreach (var operation in operations)
            {
                for (int y = operation.YCoordinates.Item1; y <= operation.YCoordinates.Item2; y++)
                {
                    for (int x = operation.XCoordinates.Item1; x <= operation.XCoordinates.Item2; x++)
                    {
                        if (operation.OperationType == OperationType.TurnOn)
                        {
                            _lamps[x, y]++;
                        }
                        else if (operation.OperationType == OperationType.TurnOff)
                        {
                            if (_lamps[x, y] == 0)
                            {
                                _lamps[x, y] = 0;
                            }
                            else
                            {
                                _lamps[x, y]--;
                            }
                        }
                        else
                        {
                            _lamps[x, y] += 2;
                        }
                    }
                }
            }
        }
    }
}
