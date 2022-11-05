namespace Day06_ProbablyAFireHazard
{
    internal class HouseDecoration
    {
        private bool[,] _lamps = new bool[1000, 1000];

        internal int CountLightedUp() => _lamps.Cast<bool>().ToList().Where(x => x == true).Count();

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
                            _lamps[x, y] = true;
                        }
                        else if (operation.OperationType == OperationType.TurnOff)
                        {
                            _lamps[x, y] = false;
                        }
                        else
                        {
                            _lamps[x, y] = !_lamps[x, y];
                        }
                    }
                }
            }
        }
    }
}
